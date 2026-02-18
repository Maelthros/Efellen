using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Custom.Ascensions
{
    public class ArchmageArcaneStormAbility : AscensionAbility
    {
        public override string Name
        {
            get { return "Arcane Storm"; }
        }

        public override AscensionType Ascension
        {
            get { return AscensionType.Archmage; }
        }

        public override int RequiredLevel
        {
            get { return 1; }
        }

        public override bool IsPassive
        {
            get { return false; }
        }

        public override TimeSpan Cooldown
        {
            get { return TimeSpan.FromSeconds(45); } 
        }

        public override void Execute(PlayerMobile pm)
        {
            if (!CanUse(pm))
            {
                pm.SendMessage("You cannot use Arcane Storm.");
                return;
            }

            if (pm.IsAbilityOnCooldown(Name))
            {
                pm.SendMessage("That ability is on cooldown.");
                return;
            }

            if (pm.Mana < 45)
            {
                pm.SendMessage("You do not have enough mana.");
                return;
            }

            pm.SendMessage("Select your target.");
            pm.Target = new ArcaneStormTarget(this);
        }

        private class ArcaneStormTarget : Target
        {
            private ArchmageArcaneStormAbility m_Ability;

            public ArcaneStormTarget(ArchmageArcaneStormAbility ability)
                : base(12, false, TargetFlags.Harmful)
            {
                m_Ability = ability;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                PlayerMobile pm = from as PlayerMobile;

                if (pm == null)
                    return;

                Mobile target = targeted as Mobile;

                if (target == null || !target.Alive || !pm.CanBeHarmful(target))
                {
                    pm.SendMessage("That is not a valid target.");
                    return;
                }

                m_Ability.PerformStorm(pm, target);
            }
        }

        public void PerformStorm(PlayerMobile pm, Mobile target)
        {
            AscensionProgress prog = pm.AscensionProfile.Get(Ascension);
            int level = prog.Level;
            pm.PublicOverheadMessage(
                MessageType.Regular,
                0x22,
                false,
                "*Missile Storm*"
            );
            pm.DoHarmful(target);
            pm.Mana -= 45;

            int missiles = 6 + (level / 3);

            for (int i = 0; i < missiles; i++)
            {
                Timer.DelayCall(
                    TimeSpan.FromSeconds(i * 0.25),
                    new TimerStateCallback(DelayedMissile),
                    new object[] { pm, target, level }
                );
                Timer.DelayCall(TimeSpan.FromSeconds(i * 0.3), delegate ()
                {
                    if (target == null || !target.Alive || target.Deleted)
                        return;

                    Effects.SendMovingEffect(
                        pm, 
                        target, 
                        0x379F, 
                        7, 
                        0, 
                        false, 
                        false, 
                        0x0213, 
                        0
                    );
                    Effects.PlaySound(pm.Location, pm.Map, 0x1F5);

                    Timer.DelayCall(TimeSpan.FromSeconds(0.5), delegate ()
                    {
                        if (target == null || !target.Alive || target.Deleted)
                            return;

                        Effects.SendLocationEffect(
                            target.Location, 
                            target.Map, 
                            0x3709, 
                            10, 
                            30, 
                            0x0213, 
                            0
                        );
                        target.FixedParticles(0x36BD, 6, 10, 5044, 0x0213, 0, EffectLayer.Waist);
                    });
                });
            }

            double cd = 45.0 - (1.0 / level);
            pm.SetAbilityCooldown(Name, TimeSpan.FromSeconds(cd));
        }



        private void DelayedMissile(object state)
        {
            object[] args = (object[])state;

            PlayerMobile caster = args[0] as PlayerMobile;
            Mobile target = args[1] as Mobile;
            int level = (int)args[2];

            if (caster == null || target == null)
                return;

            if (target.Deleted || !target.Alive)
                return;

            int bonus = (caster.Int / 25) + (level / 3);
            int damage = Utility.RandomMinMax(10, 18) + bonus;

            AOS.Damage(target, caster, damage, 0, 0, 0, 0, 100);

            HandleProcs(caster, target, level);

            if (level >= 20 && !target.Alive)
            {
                caster.SetAbilityCooldown("Conflux", TimeSpan.Zero);
                caster.SendMessage("Your Conflux cooldown has been reset!");
            }
        }

        private void HandleProcs(PlayerMobile caster, Mobile target, int level)
        {
            if (level >= 10)
            {
                int chance = level * 3;

                if (Utility.Random(100) < chance)
                {
                    int resistDrop = 8 + (level / 4);
                    int duration = 12 + (level / 2);

                    ResistanceMod mod = new ResistanceMod(ResistanceType.Energy, -resistDrop);
                    target.AddResistanceMod(mod);

                    Timer.DelayCall(
                        TimeSpan.FromSeconds(duration),
                        new TimerStateCallback(RemoveResist),
                        new object[] { target, mod }
                    );
                }
            }

            if (level >= 15)
            {
                int stamLoss = 34 + (level / 2);

                if (target.Stam >= stamLoss)
                    target.Stam -= stamLoss;
                else
                    target.Stam = 0;
            }
        }

        private void RemoveResist(object state)
        {
            object[] args = (object[])state;

            Mobile m = args[0] as Mobile;
            ResistanceMod mod = args[1] as ResistanceMod;

            if (m != null && mod != null)
                m.RemoveResistanceMod(mod);
        }
    }
}
