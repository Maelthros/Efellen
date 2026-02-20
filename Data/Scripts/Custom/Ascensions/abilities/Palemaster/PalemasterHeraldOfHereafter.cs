using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Custom.Ascensions
{
    public static class PalemasterHeraldOfHereafter
    {
        public static void TryTrigger(PlayerMobile pm)
        {
            if (pm == null || pm.Deleted)
                return;

            if (!pm.HasActiveAscension || pm.ActiveAscension != AscensionType.Palemaster)
                return;

            AscensionProgress prog = pm.AscensionProfile.Get(AscensionType.Palemaster);

            if (prog == null || prog.Level < 20)
                return;

            int level = prog.Level;

            double chance = 0.0025 * level;

            if (Utility.RandomDouble() > chance)
                return;

            SpawnCorruptions(pm, level);
        }

        private static void SpawnCorruptions(PlayerMobile caster, int level)
        {
            Map map = caster.Map;
            Point3D origin = caster.Location;

            if (map == null)
                return;

            int count = Utility.RandomMinMax(6, 12);
            int durationSeconds = Utility.RandomMinMax(12, 22);

            int spawned = 0;

            for (int i = 0; i < 20 && spawned < count; i++)
            {
                int xOffset = Utility.RandomMinMax(-7, 7);
                int yOffset = Utility.RandomMinMax(-7, 7);

                Point3D loc = new Point3D(origin.X + xOffset, origin.Y + yOffset, origin.Z);

                if (!map.CanFit(loc, 16, false, false))
                    continue;

                if (HasFieldAt(map, loc))
                    continue;

                bool eastToWest = Utility.RandomBool();
                int itemID = eastToWest ? 0x3915 : 0x3922;

                new CorruptionField(itemID, loc, caster, map, TimeSpan.FromSeconds(durationSeconds));

                spawned++;
            }

            Effects.PlaySound(origin, map, 0x20B);
        }

        private static bool HasFieldAt(Map map, Point3D loc)
        {
            IPooledEnumerable eable = map.GetItemsInRange(loc, 0);

            foreach (Item item in eable)
            {
                if (item is CorruptionField)
                {
                    eable.Free();
                    return true;
                }
            }

            eable.Free();
            return false;
        }
    }

    public class CorruptionField : Item
    {
        private PlayerMobile m_Caster;
        private Timer m_ExpireTimer;
        private Timer m_DamageTimer;

        public override bool BlocksFit { get { return false; } }

        public CorruptionField(int itemID, Point3D loc, PlayerMobile caster, Map map, TimeSpan duration)
            : base(itemID)
        {
            Movable = false;
            Visible = true;
            Hue = 0xB97;
            Light = LightType.Circle300;

            MoveToWorld(loc, map);

            m_Caster = caster;

            m_ExpireTimer = new ExpireTimer(this, duration);
            m_ExpireTimer.Start();

            m_DamageTimer = new DamageTimer(this);
            m_DamageTimer.Start();
        }

        public CorruptionField(Serial serial) : base(serial) { }

        public override void OnAfterDelete()
        {
            base.OnAfterDelete();

            if (m_ExpireTimer != null)
                m_ExpireTimer.Stop();

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
            private CorruptionField m_Field;

            public ExpireTimer(CorruptionField field, TimeSpan duration)
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
            private CorruptionField m_Field;

            public DamageTimer(CorruptionField field)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.0))
            {
                Priority = TimerPriority.OneSecond;
                m_Field = field;
            }

            protected override void OnTick()
            {
                if (m_Field.Deleted || m_Field.Map == null || m_Field.m_Caster == null)
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
                        0xB97,
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