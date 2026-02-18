using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Custom.Ascensions
{
    public class ArchmageTimestopAbility : AscensionAbility
    {
        public override string Name
        {
            get { return "Time Stop"; }
        }

        public override AscensionType Ascension
        {
            get { return AscensionType.Archmage; }
        }

        public override int RequiredLevel
        {
            get { return 18; }
        }

        public override bool IsPassive
        {
            get { return false; }
        }

        public override TimeSpan Cooldown
        {
            get { return TimeSpan.FromSeconds(180); } 
        }

        public override void Execute(PlayerMobile pm)
        {
            if (!CanUse(pm))
            {
                pm.SendMessage("You cannot use Time Stop.");
                return;
            }
            if (pm.IsAbilityOnCooldown(Name))
            {
                pm.SendMessage("That ability is on cooldown.");
                return;
            }
            if (pm.Mana < 60)
            {
                pm.SendMessage("You do not have enough mana.");
                return;
            }

            AscensionProgress prog = pm.AscensionProfile.Get(Ascension);
            int level = prog.Level;

            int range = 3 + (level / 5);
            double duration = 6 + (level / 4);
            bool drainOnExpire = (level >= 20);
            int drain = 20 + level;

            IPooledEnumerable eable = pm.Map.GetMobilesInRange(pm.Location, range);
            System.Collections.Generic.List<Mobile> targets = new System.Collections.Generic.List<Mobile>();

            foreach (Mobile m in eable)
            {
                if (m != pm && m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;
                    if (bc.Alive && !bc.IsDeadBondedPet && bc.Controlled == false)
                    {
                        targets.Add(m);
                    }
                }
            }
            eable.Free();

            foreach (Mobile target in targets)
            {
                target.Paralyze(TimeSpan.FromSeconds(duration));
                Effects.SendLocationEffect(target.Location, target.Map, 0x376A, 20, 10, 0x0213, 0);
                pm.DoHarmful(target);

                if (drainOnExpire)
                {
                    if (target.Mana >= drain)
                        target.Mana -= drain;
                    else
                        target.Mana = 0;

                    if (target.Stam >= drain)
                        target.Stam -= drain;
                    else
                        target.Stam = 0;
                }
            }

            pm.Mana -= 60;
            pm.SetAbilityCooldown(Name, TimeSpan.FromSeconds(180));
        }
    }
}
