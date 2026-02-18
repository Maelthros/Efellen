using Server.Gumps;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Custom.Ascensions
{
    public class AscensionQuickbarGump : Gump
    {
        private PlayerMobile _pm;

        public AscensionQuickbarGump(PlayerMobile pm) : base(20, 200)
        {
            _pm = pm;

            List<AscensionAbility> abilities =
                AscensionAbilityRegistry.GetAbilities(pm.ActiveAscension);

            List<AscensionAbility> usable = new List<AscensionAbility>();

            foreach (AscensionAbility ability in abilities)
            {
                if (ability.IsPassive)
                    continue;

                if (!ability.CanUse(pm))
                    continue;

                usable.Add(ability);
            }

            int rowHeight = 32;
            int height = 20 + (usable.Count * rowHeight) + 10;

            AddBackground(0, 0, 250, height, 9270);

            int y = 15;
            int buttonID = 1;

            foreach (AscensionAbility ability in usable)
            {
                AddButton(10, y, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
                AddLabel(45, y + 3, 1152, ability.Name);

                y += rowHeight;
                buttonID++;
            }
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            if (_pm == null || _pm.Deleted)
                return;

            List<AscensionAbility> abilities =
                AscensionAbilityRegistry.GetAbilities(_pm.ActiveAscension);

            List<AscensionAbility> usable = new List<AscensionAbility>();

            foreach (AscensionAbility ability in abilities)
            {
                if (ability.IsPassive)
                    continue;

                if (!ability.CanUse(_pm))
                    continue;

                usable.Add(ability);
            }

            int index = info.ButtonID - 1;

            if (index >= 0 && index < usable.Count)
            {
                usable[index].Execute(_pm);

                _pm.CloseGump(typeof(AscensionQuickbarGump));
                _pm.SendGump(new AscensionQuickbarGump(_pm));
            }
        }
    }
}
