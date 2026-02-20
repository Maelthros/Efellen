using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.EffectsUtil;

namespace Server.Custom.Ascensions
{
    public class PaleMasterEnervateAbility : AscensionAbility
    {
        public override string Name
        {
            get { return "Enervate"; }
        }

        public override AscensionType Ascension
        {
            get { return AscensionType.Palemaster; }
        }

        public override int RequiredLevel
        {
            get { return 6; }
        }

        public override bool IsPassive
        {
            get { return false; }
        }

        public override TimeSpan Cooldown
        {
            get { return TimeSpan.FromSeconds(60); } 
        }

        public override void Execute(PlayerMobile pm)
        {
            if (!CanUse(pm))
            {
                pm.SendMessage("You cannot use Enervate.");
                return;
            }

            if (pm.IsAbilityOnCooldown(Name))
            {
                pm.SendMessage("That ability is on cooldown.");
                return;
            }

            if (pm.Mana < 30)
            {
                pm.SendMessage("You do not have enough mana.");
                return;
            }

            AscensionProgress prog = pm.AscensionProfile.Get(Ascension);
            int level = prog.Level;

            DoEnervate(pm, level);
        }

        private void DoEnervate(PlayerMobile pm, int level)
        {
            pm.PublicOverheadMessage(
                MessageType.Regular,
                0x22,
                false,
                "*Enervate*"
            );
            int radius = 3 + (level / 5);
            int damage = 40 + (level / 3);

            int maxLeech = 50;
            if (level >= 12)
                maxLeech = 100;

            int totalHeal = 0;
            int totalMana = 0;
            pm.Mana -= 30;

            SlamVisuals.SlamVisual(pm, radius, 0x36B0, 1153);
           
            IPooledEnumerable eable = pm.Map.GetMobilesInRange(pm.Location, radius);

            foreach (Mobile m in eable)
            {
                if (m == null || m.Deleted || !m.Alive || m == pm)
                    continue;

                if (!pm.CanBeHarmful(m))
                    continue;

                SlayerEntry undead = SlayerGroup.GetEntryByName(SlayerName.Silver);
                SlayerEntry exorcism = SlayerGroup.GetEntryByName(SlayerName.Exorcism);

                if (undead.Slays(m) || exorcism.Slays(m))
                    continue;

                AOS.Damage(m, pm, damage, 0, 0, 100, 0, 0);
                pm.DoHarmful(m);
                if (m.Mana >= damage)
                    m.Mana -= damage;
                else
                    m.Mana = 0;

                totalHeal += 5;
                totalMana += 5;

                int debuffPercent = 5 + (level / 5);

                ApplyStatDebuff(m, debuffPercent);
            }
            eable.Free();

            if (totalHeal > maxLeech)
                totalHeal = maxLeech;

            if (totalMana > maxLeech)
                totalMana = maxLeech;

            if (pm.Hits + totalHeal > pm.HitsMax)
                pm.Hits = pm.HitsMax;
            else
                pm.Hits += totalHeal;

            if (pm.Mana + totalMana > pm.ManaMax)
                pm.Mana = pm.ManaMax;
            else
                pm.Mana += totalMana;

            pm.FixedParticles(0x374A, 10, 15, 5021, 2075, 0, EffectLayer.Waist);
            pm.PlaySound(0x1F8);
            pm.SetAbilityCooldown(Name, TimeSpan.FromSeconds(60));
        }

        private static void ApplyStatDebuff(Mobile m, int percent)
        {
            int strLoss = (m.RawStr * percent) / 100;
            int dexLoss = (m.RawDex * percent) / 100;

            if (strLoss < 1)
                strLoss = 1;

            if (dexLoss < 1)
                dexLoss = 1;

            StatMod strMod = new StatMod(
                StatType.Str,
                "EnervateStr",
                -strLoss,
                TimeSpan.FromSeconds(30)
            );

            StatMod dexMod = new StatMod(
                StatType.Dex,
                "EnervateDex",
                -dexLoss,
                TimeSpan.FromSeconds(30)
            );
            m.AddStatMod(strMod);
            m.AddStatMod(dexMod);
        }       
    }
}
