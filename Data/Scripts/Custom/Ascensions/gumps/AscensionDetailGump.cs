using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Custom.Ascensions;

namespace Server.Custom.Ascensions.Gumps
{
    public class AscensionDetailGump : Gump
    {
        private PlayerMobile m_Player;
        private AscensionType m_Type;

        public AscensionDetailGump(PlayerMobile pm, AscensionType type) : base(120, 80)
        {
            m_Player = pm;
            m_Type = type;

            AscensionProgress prog = pm.AscensionProfile.Get(type);

            AddPage(0);
            AddBackground(0, 0, 520, 450, 9270);

            AddLabel(180, 15, 1152, type.ToString());

            AddLabel(30, 60, 1153, "Level: " + prog.Level);

            int requiredExp = prog.GetRequiredExperience();

            if (!prog.IsMaxLevel())
            {
                AddLabel(30, 85, 1153,
                    "Experience: " + prog.Experience + " / " + requiredExp);
            }
            else
            {
                AddLabel(30, 85, 68, "Maximum Level Reached");
            }


            // Fake progress bar (visual only)
            double percent = (double)prog.Experience / requiredExp;
            int width = (int)(300 * percent);

            AddBackground(30, 110, 300, 20, 9200);
            AddBackground(30, 110, width, 20, 9300);

            // Benefits
            AddLabel(30, 150, 1152, "Benefits:");
            AddHtml(30, 170, 460, 80, GetBenefits(type), true, true);

            // Abilities
            AddLabel(30, 260, 1152, "Granted Abilities:");
            AddHtml(30, 280, 460, 80, GetAbilities(type), true, true);

            // Upgrade section
            if (prog.CanLevelUp())
            {
                int next = prog.GetNextLevel();
                int gold = AscensionCosts.GetGoldCost(next);
                int dust = AscensionCosts.GetDustCost(next);
                int scrolls = AscensionCosts.GetScrollCost(next);
            
                AddLabel(350, 85, 1153,
                "Cost: " + gold + "g / " +
                dust + " dust / " +
                scrolls + " scrolls");
            
                AddButton(350, 110, 4005, 4007, 3000 + (int)type, GumpButtonType.Reply, 0);
                AddLabel(385, 110, 68, "Upgrade");
            }
            if (prog.Level > 0)
            {
                AddButton(40, 290, 4005, 4007, 2, GumpButtonType.Reply, 0);
                AddLabel(75, 290, 1152, "Activate Ascension");
            }


            AddButton(200, 400, 4017, 4019, 1, GumpButtonType.Reply, 0);
            AddLabel(235, 400, 1152, "Back");
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 1)
            {
                m_Player.SendGump(new AscensionSelectionGump(m_Player));
                return;
            }
            if (info.ButtonID == 2)
            {
                m_Player.ActivateAscension(m_Type);
                m_Player.SendGump(new AscensionDetailGump(m_Player, m_Type));
            }


            if (info.ButtonID >= 3000)
            {
                AscensionType type = (AscensionType)(info.ButtonID - 3000);
                m_Player.SendGump(new AscensionUpgradeConfirmGump(m_Player, type));
            }
        }

        private string GetBenefits(AscensionType type)
        {
            return AscensionDefinitions.GetBenefits(type);
        }

        private string GetAbilities(AscensionType type)
        {
            return AscensionDefinitions.GetAbilities(type);
        }
    }
}
