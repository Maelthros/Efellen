using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Custom.Ascensions;

namespace Server.Custom.Ascensions
{
    public class AscensionSelectionGump : Gump
    {
        private PlayerMobile m_Player;

        public AscensionSelectionGump(PlayerMobile pm) : base(100, 100)
        {
            m_Player = pm;

            Closable = true;
            Dragable = true;

            AddPage(0);
            AddBackground(0, 0, 500, 400, 9270);
            AddLabel(180, 15, 1152, "Ascensions");

            int y = 50;

            foreach (AscensionType type in Enum.GetValues(typeof(AscensionType)))
            {
                if (type == AscensionType.None)
                    continue;

                AddEntry(type, y);
                y += 40;
            }
        }

        private void AddEntry(AscensionType type, int y)
        {
            AscensionProgress prog = m_Player.AscensionProfile.Get(type);

            AddLabel(30, y, 1152, type.ToString());

            if (prog.Unlocked)
            {
                AddLabel(200, y, 68, "Level: " + prog.Level);
            }
            else
            {
                AddButton(200, y, 4005, 4007, 1000 + (int)type, GumpButtonType.Reply, 0);
                AddLabel(235, y, 33, "Unlock");
            }

            // Help button (question mark)
            AddButton(350, y, 4011, 4013, 2000 + (int)type, GumpButtonType.Reply, 0);
            AddLabel(385, y, 1152, "?");
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 0)
                return;

            // Unlock
            if (info.ButtonID >= 1000 && info.ButtonID < 2000)
            {
                AscensionType type = (AscensionType)(info.ButtonID - 1000);

                AscensionUnlocking.TryUnlock(m_Player, type);

                m_Player.SendGump(new AscensionSelectionGump(m_Player));
                return;
            }

            // Help
            if (info.ButtonID >= 2000)
            {
                AscensionType type = (AscensionType)(info.ButtonID - 2000);

                m_Player.SendGump(new AscensionDetailGump(m_Player, type));
                return;
            }
        }
    }
}
