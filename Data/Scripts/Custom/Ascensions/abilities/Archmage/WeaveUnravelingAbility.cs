using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom.Ascensions
{
    public static class WeaveUnravelingAbility
    {
        public static void Trigger(PlayerMobile caster, Mobile center)
        {
            if (center == null || center.Map == null)
                return;

            Map map = center.Map;
            Point3D origin = center.Location;

            int count = Utility.RandomMinMax(6, 12);
            int durationSeconds = Utility.RandomMinMax(12, 22);

            ArrayList spawned = new ArrayList();

            for (int i = 0; i < 20 && spawned.Count < count; i++)
            {
                int xOffset = Utility.RandomMinMax(-7, 7);
                int yOffset = Utility.RandomMinMax(-7, 7);

                Point3D loc = new Point3D(origin.X + xOffset, origin.Y + yOffset, origin.Z);

                if (!map.CanFit(loc, 16, false, false))
                    continue;

                if (HasDisruptionAt(map, loc))
                    continue;

                WeaveDisruption field = new WeaveDisruption(loc, map, caster, TimeSpan.FromSeconds(durationSeconds));
                spawned.Add(field);
            }
        }

        private static bool HasDisruptionAt(Map map, Point3D loc)
        {
            IPooledEnumerable eable = map.GetItemsInRange(loc, 0);

            foreach (Item item in eable)
            {
                if (item is WeaveDisruption)
                {
                    eable.Free();
                    return true;
                }
            }

            eable.Free();
            return false;
        }
    }

    public class WeaveDisruption : Item
    {
        private PlayerMobile m_Caster;
        private Timer m_Timer;
        private Timer m_DamageTimer;

        public override bool BlocksFit { get { return false; } }

        public WeaveDisruption(Point3D loc, Map map, PlayerMobile caster, TimeSpan duration)
            : base(0x3946)
        {
            Movable = false;
            Visible = true;
            Light = LightType.Circle300;

            Hue = 0x0213;

            MoveToWorld(loc, map);

            m_Caster = caster;

            m_Timer = new ExpireTimer(this, duration);
            m_Timer.Start();

            m_DamageTimer = new DamageTimer(this);
            m_DamageTimer.Start();

            Effects.PlaySound(loc, map, 0x20B);
        }

        public WeaveDisruption(Serial serial) : base(serial) { }

        public override void OnAfterDelete()
        {
            base.OnAfterDelete();

            if (m_Timer != null)
                m_Timer.Stop();

            if (m_DamageTimer != null)
                m_DamageTimer.Stop();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }

        private class ExpireTimer : Timer
        {
            private WeaveDisruption m_Field;

            public ExpireTimer(WeaveDisruption field, TimeSpan duration)
                : base(duration)
            {
                m_Field = field;
            }

            protected override void OnTick()
            {
                m_Field.Delete();
            }
        }

        private class DamageTimer : Timer
        {
            private WeaveDisruption m_Field;

            public DamageTimer(WeaveDisruption field)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.0))
            {
                Priority = TimerPriority.OneSecond;
                m_Field = field;
            }

            protected override void OnTick()
            {
                if (m_Field.Deleted || m_Field.Map == null)
                {
                    Stop();
                    return;
                }

                IPooledEnumerable eable = m_Field.Map.GetMobilesInRange(m_Field.Location, 0);

                foreach (Mobile m in eable)
                {
                    if (m == m_Field.m_Caster)
                        continue;

                    if (!m_Field.m_Caster.CanBeHarmful(m))
                        continue;

                    m_Field.m_Caster.DoHarmful(m);

                    int damage = Utility.RandomMinMax(14, 22);
                    damage += (m_Field.m_Caster.Int / 15);

                    AOS.Damage(m, m_Field.m_Caster, damage, 0, 0, 0, 0, 100);

                    Effects.SendLocationParticles(
                        EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration),
                        0x376A,
                        9,
                        10,
                        1161,
                        0,
                        5051,
                        0
                    );
                }

                eable.Free();
            }
        }
    }
}
