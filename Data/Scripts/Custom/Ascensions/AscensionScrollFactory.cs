using System;

namespace Server.Custom.Ascensions
{
    public class AscensionScrollFactory
    {
        private static AscensionType[] m_UnlockableAscensions = new AscensionType[]
        {
            AscensionType.Berserker,
            AscensionType.Archmage,
            AscensionType.Archdruid,
            AscensionType.Palemaster,
            AscensionType.Crusader,
            AscensionType.Kensai,
            AscensionType.Spellsword,
            AscensionType.Assassin,
            AscensionType.Reaver,
            AscensionType.Defender,
            AscensionType.Shadowthief,
        };

        public static AscensionScroll CreateRandom()
        {
            AscensionType type = m_UnlockableAscensions[
                Utility.Random(m_UnlockableAscensions.Length)
            ];

            return new AscensionScroll(type);
        }
    }
}
