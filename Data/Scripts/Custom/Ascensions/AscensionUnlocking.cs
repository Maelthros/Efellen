using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Custom.Ascensions
{
    public static class AscensionUnlocking
    {
        public static void GetUnlockCost(PlayerMobile pm, out int gold, out int dust, out int scrolls)
        {
            int totalLevels = pm.AscensionProfile.GetTotalLevels();

            if (totalLevels == 0)
            {
                gold = 500;
                dust = 250;
                scrolls = 3;
                return;
            }

            gold = totalLevels * 1000;
            dust = gold / 2;
            scrolls = 3;
        }

        public static bool TryUnlock(PlayerMobile pm, AscensionType type)
        {
            if (pm.AscensionProfile.IsUnlocked(type))
                return false;

            int gold, dust, scrolls;
            GetUnlockCost(pm, out gold, out dust, out scrolls);

            if (!HasGold(pm, gold))
            {
                pm.SendMessage("You do not have enough gold.");
                return false;
            }

            if (!HasArcaneDust(pm, dust))
            {
                pm.SendMessage("You do not have enough arcane dust.");
                return false;
            }

            if (!HasScrolls(pm, type, scrolls))
            {
                pm.SendMessage("You do not have enough " + type.ToString() + " ascension scrolls.");
                return false;
            }

            ConsumeGold(pm, gold);
            ConsumeArcaneDust(pm, dust);
            ConsumeScrolls(pm, type, scrolls);

            AscensionProgress prog = pm.AscensionProfile.Get(type);
            prog.Unlocked = true;
            prog.Level = 1;
            prog.Experience = 0;

            pm.SendMessage("You have unlocked the " + type.ToString() + " ascension.");

            return true;
        }

        internal static bool HasGold(PlayerMobile pm, int amount)
        {
            if (pm.Backpack != null && pm.Backpack.GetAmount(typeof(Gold)) >= amount)
                return true;

            if (pm.BankBox != null && pm.BankBox.GetAmount(typeof(Gold)) >= amount)
                return true;

            return false;
        }

        internal static void ConsumeGold(PlayerMobile pm, int amount)
        {
            if (pm.Backpack != null && pm.Backpack.ConsumeTotal(typeof(Gold), amount))
                return;

            if (pm.BankBox != null)
                pm.BankBox.ConsumeTotal(typeof(Gold), amount);
        }

        internal static bool HasArcaneDust(PlayerMobile pm, int amount)
        {
            return pm.Backpack != null && pm.Backpack.GetAmount(typeof(ArcaneDust)) >= amount;
        }

        internal static void ConsumeArcaneDust(PlayerMobile pm, int amount)
        {
            if (pm.Backpack != null)
                pm.Backpack.ConsumeTotal(typeof(ArcaneDust), amount);
        }

        internal static bool HasScrolls(PlayerMobile pm, AscensionType type, int amount)
        {
            if (pm == null || pm.Backpack == null)
                return false;

            int total = 0;

            foreach (Item item in pm.Backpack.Items)
            {
                AscensionScroll scroll = item as AscensionScroll;

                if (scroll != null && scroll.Ascension == type)
                {
                    total += scroll.Amount;

                    if (total >= amount)
                        return true;
                }
            }

            return false;
        }

        internal static void ConsumeScrolls(PlayerMobile pm, AscensionType type, int amount)
        {
            if (pm == null || pm.Backpack == null)
                return;

            int remaining = amount;

            for (int i = pm.Backpack.Items.Count - 1; i >= 0; i--)
            {
                AscensionScroll scroll = pm.Backpack.Items[i] as AscensionScroll;

                if (scroll != null && scroll.Ascension == type)
                {
                    if (scroll.Amount <= remaining)
                    {
                        remaining -= scroll.Amount;
                        scroll.Delete();
                    }
                    else
                    {
                        scroll.Amount -= remaining;
                        remaining = 0;
                    }

                    if (remaining <= 0)
                        break;
                }
            }
        }
    }
}
