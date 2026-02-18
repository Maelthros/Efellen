using System;

namespace Server.Custom.Ascensions
{
    public static class AscensionDefinitions
    {
        public static string GetDescription(AscensionType type)
        {
            switch (type)
            {
                case AscensionType.Berserker:
                    return
                    "The Berserker is a savage warrior that wields two-handed weapons to great effect. In combat, they fly into a murderous rage that empowers them.<br><br>" +
                    "In order to activate this Ascension, you need to have 95 base skill in both Tactics and Magic Resist. Every time you level up the class, the requirement also increases by 1.<br><br>" +
                    "So a level 20 Berserker cannot activate this ascension unless they have 115 base skill in both Tactics and Magic Resist.";

                default:
                    return "No description defined.";
            }
        }


        public static string GetAbilities(AscensionType type)
        {
            if (type != AscensionType.Berserker)
                return "No abilities defined.";

            return
            "<BASEFONT COLOR=#FFFFFF>" +
            "These are the abilities that the berserker learns as they level up:<br><br>" +

            "Rage. Level 1<br>" +
            "Command: [BerserkerRage<br>" +
            "Gain +(15+level) STR, immunity to paralyze, +10% damage, -10% defend chance.<br>" +
            "Lasts 10 + level seconds. 1 min cooldown. Ends with 50% stamina loss.<br>" +
            "Lvl 10: +level/2 resists, +5% damage, -5% defend chance.<br>" +
            "Lvl 15: Hits above 40% max HP are reduced to 40%.<br>" +
            "Lvl 20: Additional +5% damage, -5% defend chance.<br><br>" +

            "Leap Slam, Level 6<br>" +
            "Command: [BerserkerLeapSlam<br>" +
            "Leap 3 + level/4 tiles. On landing deal 20–35 + ((STR/15)+(level/3)) damage to adjacent enemies.<br>" +
            "Cooldown: 9 sec - (1 sec per 3 levels).<br>" +
            "Lvl 12: Stuns adjacent enemies for 3 sec.<br><br>" +

            "Warcry, Level 11<br>" +
            "Command: [BerserkerWarCry<br>" +
            "Enemies lose (25+level) STR, (10+level) DEX, (10+level) INT for (20+level) sec.<br>" +
            "Allies gain 2 stamina every 2 sec for same duration.<br>" +
            "Lvl 16: Enemies lose 20+2*level stamina instantly and 2+level every 2 sec.<br><br>" +

            "Tenacity,Level 18<br>" +
            "Command: [BerserkerTenacity<br>" +
            "Heal to full HP immediately and again every 10 sec for 30 sec. 2 min cooldown.<br>" +
            "Lvl 20: Also heals full stamina each pulse.<br><br>" +

            "Passives:<br>" +
            "Cleave, level 2<br>" +
            "When making a melee strike with a two handed weapon, the berserker has a 4% + 1% level chance of making another strike against an adjacent enemy<br>" +
            "At level 5, they have a 1%+1%/level chance of a second aditional strike. At level 13, they have a 1%+1%/level chance of a third aditional strike<br><br>" +

            "Uncanny dodge, level 8<br>" +
            "The berserker has a 25+1%/level chance of ignoring the effects of traps<br>"+
            "Level 17: the chance increases to 45+1%/level<br><br>"+
            
            "Pummeling Strikes, level 14<br>" +
            "When making a strike with a two handed melee weapon, the berserker has a (level/4)% chance of ignoring the target's armor<br>"+
            "Level 19: the chance increases to (levle/2)%<br><br>"+
            
            "Undying Wrath, level 20<br>" +
            "If the berserker takes a hit that would reduce their hit points to 0 or less, they reduce it to 1 instead and the cooldown on their Warcry is set to zero.<br>"+
            "This effect can trigger once per minute<br>"+
            "</BASEFONT>";
        }

    }
}
