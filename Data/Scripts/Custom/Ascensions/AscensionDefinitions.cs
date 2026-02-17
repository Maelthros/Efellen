using System;

namespace Server.Custom.Ascensions
{
    public static class AscensionDefinitions
    {
        public static string GetBenefits(AscensionType type)
        {
            switch (type)
            {
                case AscensionType.Berserker:
                    return "+ Strength scaling\n+ Melee damage bonus\n+ Rage generation";

                case AscensionType.Archdruid:
                    return "+ Spell damage\n+ Elemental resist ignore\n+ Mana efficiency";

                case AscensionType.Archmage:
                    return "+ Summon power\n+ Life drain\n+ Curse amplification";

                default:
                    return "No benefits defined.";
            }
        }

        public static string GetAbilities(AscensionType type)
        {
            switch (type)
            {
                case AscensionType.Berserker:
                    return "Rage Burst\nBlood Frenzy\nWar Cry";

                case AscensionType.Archdruid:
                    return "Chain Lightning\nFlame Surge\nFrost Nova";

                case AscensionType.Archmage:
                    return "Raise Undead\nSoul Drain\nDeath Pact";

                default:
                    return "No abilities defined.";
            }
        }
    }
}
