using Server;

namespace Server.Custom.Ascensions
{
    public class ShadowthiefAscension : AscensionDefinition
    {
        public override AscensionType Type { get { return AscensionType.Shadowthief; } }

        public override SkillName[] RequiredSkills
        {
            get { return new SkillName[] { SkillName.Stealing, SkillName.Hiding }; }
        }

        public override SkillName[] ForbiddenSkills
        {
            get { return new SkillName[] { SkillName.Knightship, SkillName.Bushido }; }
        }
    }
}
