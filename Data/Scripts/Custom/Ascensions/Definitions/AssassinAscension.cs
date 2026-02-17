using Server;

namespace Server.Custom.Ascensions
{
    public class AssassinAscension : AscensionDefinition
    {
        public override AscensionType Type { get { return AscensionType.Assassin; } }

        public override SkillName[] RequiredSkills
        {
            get { return new SkillName[] { SkillName.Poisoning, SkillName.Stealth }; }
        }

        public override SkillName[] ForbiddenSkills
        {
            get { return new SkillName[] { SkillName.Knightship }; }
        }

        public override bool RequiresEvil { get { return true; } }
    }
}
