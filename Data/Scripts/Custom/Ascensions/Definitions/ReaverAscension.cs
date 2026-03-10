using Server;

namespace Server.Custom.Ascensions
{
    public class ReaverAscension : AscensionDefinition
    {
        public override AscensionType Type { get { return AscensionType.Reaver; } }

        public override SkillName[] RequiredSkills
        {
            get { return new SkillName[] { SkillName.Tactics, SkillName.Anatomy }; }
        }

        public override SkillName[] ForbiddenSkills
        {
            get { return new SkillName[] { SkillName.Healing, SkillName.Veterinary }; }
        }
    }
}
