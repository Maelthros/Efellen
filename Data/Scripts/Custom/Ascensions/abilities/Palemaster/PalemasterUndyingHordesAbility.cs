using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;

namespace Server.Custom.Ascensions
{
    public class PalemasterUndyingHordesAbility : AscensionAbility
    {
        public override AscensionType Ascension { get { return AscensionType.Palemaster; } }
        public override int RequiredLevel { get { return 1; } }
        public override string Name { get { return "Undying Hordes"; } }
        public override bool IsPassive { get { return false; } }
        

        public override TimeSpan Cooldown
        {
            get { return TimeSpan.FromMinutes(4); }
        }

        public override void Execute(PlayerMobile pm)
        {
            if (!CanUse(pm))
                return;

            if (pm.IsAbilityOnCooldown(Name))
            {
                pm.SendMessage("That ability is on cooldown.");
                return;
            }

            AscensionProgress prog = pm.AscensionProfile.Get(AscensionType.Palemaster);
            if (prog == null)
                return;

            int level = prog.Level;

            pm.PublicOverheadMessage(MessageType.Regular, 0x48C, false, "*Undying Hordes*");
            pm.SendMessage("You call forth the undying hordes!");

            pm.SetAbilityCooldown(Name, Cooldown);

            TimeSpan duration = TimeSpan.FromSeconds(60 + (level * 3));

            ArrayList summons = SpawnHorde(pm, level);

            HordeTimer timer = new HordeTimer(summons, pm, duration);
            timer.Start();

            CooldownNotifyTimer cdTimer = new CooldownNotifyTimer(pm, Cooldown);
            cdTimer.Start();
        }

        private ArrayList SpawnHorde(PlayerMobile pm, int level)
        {
            ArrayList list = new ArrayList();

            Map map = pm.Map;
            if (map == null)
                return list;

            int spawnCount = 0;

            if (level <= 4)
            {
                spawnCount += SpawnRange(pm, list, level, 3, 5, typeof(PaleMasterSkeleton));
                spawnCount += SpawnRange(pm, list, level, 2, 3, typeof(PaleMasterSkeletonWarrior));
            }
            else if (level <= 8)
            {
                spawnCount += SpawnRange(pm, list, level, 3, 5, typeof(PaleMasterSkeleton));
                spawnCount += SpawnRange(pm, list, level, 2, 3, typeof(PaleMasterSkeletonWarrior));
                spawnCount += SpawnRange(pm, list, level, 1, 2, typeof(PaleMasterSkeletonKnight));
            }
            else if (level <= 12)
            {
                spawnCount += SpawnRange(pm, list, level, 3, 4, typeof(PaleMasterSkeletonWarrior));
                spawnCount += SpawnRange(pm, list, level, 2, 3, typeof(PaleMasterSkeletonKnight));
                spawnCount += SpawnRange(pm, list, level, 1, 2, typeof(PaleMasterMummy));
            }
            else if (level <= 16)
            {
                spawnCount += SpawnRange(pm, list, level, 2, 3, typeof(PaleMasterSkeletonKnight));
                spawnCount += SpawnRange(pm, list, level, 2, 3, typeof(PaleMasterMummy));
                spawnCount += SpawnRange(pm, list, level, 1, 2, typeof(PaleMasterMummyLord));
                spawnCount += SpawnRange(pm, list, level, 1, 1, typeof(PaleMasterUndeadGiant));
            }
            else if (level <= 19)
            {
                spawnCount += SpawnRange(pm, list, level, 3, 4, typeof(PaleMasterUndeadGiant));
                spawnCount += SpawnRange(pm, list, level, 2, 3, typeof(PaleMasterMummyLord));
                spawnCount += SpawnRange(pm, list, level, 1, 1, typeof(PaleMasterSkeletalDragon));
            }
            else
            {
                spawnCount += SpawnRange(pm, list, level, 4, 5, typeof(PaleMasterUndeadGiant));
                spawnCount += SpawnRange(pm, list, level, 3, 4, typeof(PaleMasterMummyLord));
                spawnCount += SpawnRange(pm, list, level, 1, 2, typeof(PaleMasterSkeletalDragon));
            }

            return list;
        }

        private int SpawnRange(PlayerMobile pm, ArrayList list, int level, int min, int max, Type type)
        {
            int amount = Utility.RandomMinMax(min, max);
            int spawned = 0;

            for (int i = 0; i < amount; i++)
            {
                BaseCreature bc = Activator.CreateInstance(type) as BaseCreature;

                if (bc == null)
                    continue;

                if (!TrySpawnNear(pm, bc))
                {
                    bc.Delete();
                    continue;
                }

                bc.Summoned = true;
                bc.SummonMaster = pm;
                bc.IsTempEnemy = true;
                bc.ControlSlots = 0;
                bc.Controlled = false;
                bc.FightMode = FightMode.Closest;
                bc.RangeHome = 10;
                bc.Home = pm.Location;

                Effects.SendLocationEffect(
                    bc.Location,
                    bc.Map,
                    0x3728,
                    15,
                    10,
                    2075,
                    0
                );

                list.Add(bc);
                spawned++;
            }

            return spawned;
        }

        private bool TrySpawnNear(PlayerMobile pm, BaseCreature bc)
        {
            Map map = pm.Map;
            Point3D loc = pm.Location;

            for (int i = 0; i < 10; i++)
            {
                int x = loc.X + Utility.RandomMinMax(-3, 3);
                int y = loc.Y + Utility.RandomMinMax(-3, 3);
                Point3D spawn = new Point3D(x, y, loc.Z);

                if (map.CanFit(spawn, 16, false, false))
                {
                    bc.MoveToWorld(spawn, map);
                    return true;
                }
            }
            return false;
        }

        private class HordeTimer : Timer
        {
            private ArrayList m_List;
            private PlayerMobile m_Master;
        
            public HordeTimer(ArrayList list, PlayerMobile master, TimeSpan duration)
                : base(duration)
            {
                m_List = list;
                m_Master = master;

            }

            protected override void OnTick()
            {
                foreach (BaseCreature bc in m_List)
                {
                    if (bc != null && !bc.Deleted)
                    {
                        Effects.SendLocationEffect(
                            bc.Location,
                            bc.Map,
                            0x3728,
                            15,
                            10,
                            2075,
                            0
                        );
                        bc.Delete();
                    }
                }

                m_List.Clear();
            }
        }

        private class CooldownNotifyTimer : Timer
        {
            private PlayerMobile m_Player;

            public CooldownNotifyTimer(PlayerMobile pm, TimeSpan delay)
                : base(delay)
            {
                m_Player = pm;
            }

            protected override void OnTick()
            {
                if (m_Player != null)
                    m_Player.SendMessage("You can call the undying hordes again.");
            }
        }
    }
}
