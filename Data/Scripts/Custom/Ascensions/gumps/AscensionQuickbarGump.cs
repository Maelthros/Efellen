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

            AddBackground(0, 0, 250, 60, 9270);

            List<AscensionAbility> abilities =
                AscensionAbilityRegistry.GetAbilities(pm.ActiveAscension);

            int x = 10;
            int buttonID = 1;

            foreach (AscensionAbility ability in abilities)
            {
                if (ability.IsPassive)
                    continue;

                if (!ability.CanUse(pm))
                    continue;

                AddButton(x, 15, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
                AddLabel(x, 40, 1152, ability.Name);

                x += 60;
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
