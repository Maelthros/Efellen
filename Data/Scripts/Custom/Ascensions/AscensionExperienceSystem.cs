using Server;
using Server.Mobiles;

namespace Server.Custom.Ascensions
{
    public static class AscensionExperienceSystem
    {
        public static void AwardExperience(PlayerMobile pm, BaseCreature creature)
        {
            if (pm == null || creature == null)
                return;

            if (!pm.HasActiveAscension)
                return;

            AscensionType type = pm.ActiveAscension;

            AscensionProgress prog = pm.AscensionProfile.Get(type);

            if (prog.Level >= AscensionConstants.MaxAscensionLevel)
                return;

            if (prog.IsExperienceCapped())
                return;

            int fame = creature.Fame;

            if (fame <= 0)
                return;

            int min = fame / 125;
            int max = fame / 95;

            if (max <= 0)
                return;

            int amount = Utility.RandomMinMax(min, max);

            prog.AddExperience(amount);

            pm.SendMessage(1153, "You gain " + amount + " ascension experience.");
        }

        public static void AwardExperienceDirect(PlayerMobile pm, BaseCreature creature, int amount)
        {
            if (pm == null || creature == null || amount <= 0)
                return;

            if (!pm.HasActiveAscension)
                return;

            AscensionType type = pm.ActiveAscension;
            AscensionProgress prog = pm.AscensionProfile.Get(type);

            if (prog.Level >= AscensionConstants.MaxAscensionLevel)
                return;

            if (prog.IsExperienceCapped())
                return;

            prog.AddExperience(amount);

            pm.SendMessage(1153, "You gain " + amount + " ascension experience.");
        }
    }
}
