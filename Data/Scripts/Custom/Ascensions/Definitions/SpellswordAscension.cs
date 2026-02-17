using Server;

namespace Server.Custom.Ascensions
{
    public class SpellswordAscension : AscensionDefinition
    {
        public override AscensionType Type { get { return AscensionType.Spellsword; } }

        public override SkillName[] RequiredSkills
        {
            get { return new SkillName[] { SkillName.Tactics, SkillName.Magery }; }
        }

        public override SkillName[] ForbiddenSkills
        {
            get { return new SkillName[] { SkillName.Bushido, SkillName.Knightship }; }
        }
    }
}
