using System;

namespace Server.Custom.Ascensions
{
    public class AscensionScrollFactory
    {
        private static AscensionType[] m_UnlockableAscensions = new AscensionType[]
        {
            AscensionType.Berserker,
            AscensionType.Archmage,
            AscensionType.Palemaster,
            AscensionType.Assassin,
            AscensionType.Crusader,
            AscensionType.Blackguard,
            AscensionType.Skald,
        // not implemented yet
/*             AscensionType.Kensai,
            AscensionType.Archdruid,
            AscensionType.Reaver,
            AscensionType.Defender,
            AscensionType.Shadowthief, */
        };

        public static AscensionType GetRandom()
        {
            return m_UnlockableAscensions[Utility.Random(m_UnlockableAscensions.Length)];
        }

        public static AscensionScroll CreateRandom()
        {
            AscensionType type = m_UnlockableAscensions[
                Utility.Random(m_UnlockableAscensions.Length)
            ];

            return new AscensionScroll(type);
        }
    }
}
