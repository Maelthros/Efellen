using Server;

namespace Server.Custom.Ascensions
{
    public class DefenderAscension : AscensionDefinition
    {
        public override AscensionType Type { get { return AscensionType.Defender; } }

        public override SkillName[] RequiredSkills
        {
            get { return new SkillName[] { SkillName.Tactics, SkillName.Parry }; }
        }

        public override SkillName[] ForbiddenSkills
        {
            get { return new SkillName[] { SkillName.Bushido, SkillName.Magery, SkillName.Necromancy, SkillName.Elementalism }; }
        }
    }
}
