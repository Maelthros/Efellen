using Server;

namespace Server.Custom.Ascensions
{
    public class PalemasterAscension : AscensionDefinition
    {
        public override AscensionType Type { get { return AscensionType.Palemaster; } }

        public override SkillName[] RequiredSkills
        {
            get { return new SkillName[] { SkillName.Necromancy, SkillName.Spiritualism }; }
        }

        public override SkillName[] ForbiddenSkills
        {
            get { return new SkillName[] { SkillName.Knightship }; }
        }

        public override bool RequiresEvil { get { return true; } }
    }
}
