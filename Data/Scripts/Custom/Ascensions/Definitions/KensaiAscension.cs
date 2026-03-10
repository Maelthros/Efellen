using Server;

namespace Server.Custom.Ascensions
{
    public class KensaiAscension : AscensionDefinition
    {
        public override AscensionType Type { get { return AscensionType.Kensai; } }

        public override SkillName[] RequiredSkills
        {
            get { return new SkillName[] { SkillName.Bushido, SkillName.ArmsLore }; }
        }

        public override SkillName[] ForbiddenSkills
        {
            get { return new SkillName[] { SkillName.Knightship, SkillName.Necromancy, SkillName.Elementalism, SkillName.Magery }; }
        }
    }
}
