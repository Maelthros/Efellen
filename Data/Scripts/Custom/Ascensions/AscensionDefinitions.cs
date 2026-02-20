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
                    "So a level 20 Berserker cannot activate this ascension unless they have 115 base skill in both Tactics and Magic Resist.<br><br>"+
                    "Berserkers also require their spirit to be free of the taint of civilization - a Berserker will not gain experience in this Ascension if they have learned Bushido, Knightship, Magery or Necromancy";
                case AscensionType.Archmage:
                    return
                    "The Archmage is a master of the Arcane. In combat, they control their opponents and execute powerful spells to bend the Weave itself to their will itself.<br><br>" +
                    "In order to activate this Ascension, you need to have 95 base skill in both Magery and Psychology. Every time you level up the class, the requirement also increases by 1.<br><br>" +
                    "So a level 20 Archmage cannot activate this ascension unless they have 115 base skill in both Magery and Psychology<br><br>"+
                    "Archmages also require a singular focus on arcane magic, and they will not gain experience in this class if they have learned Knightship, Elementalism, Necromancy or Bushido";
                case AscensionType.Palemaster:
                    return
                    "The Palemaster is death made flesh. In combat, they control an army of undead and curse and enfeeble their opponents until they have met their end.<br><br>" +
                    "In order to activate this Ascension, you need to have 95 base skill in both Necromancy and Spiritualism. Every time you level up the class, the requirement also increases by 1.<br><br>" +
                    "So a level 20 Palemaster cannot activate this ascension unless they have 115 base skill in both Necromancy and Spiritualism<br><br>"+
                    "Palemasters also are required to revel in death and vileness, and they will not gain experience in this class if they have learned Knightship, Elementalism or Bushido, or if they stray from the path of evil";
                default:
                    return "No description defined.";
            }
        }


        public static string GetAbilities(AscensionType type)
        {
            if(type == AscensionType.Berserker)
            {
                return
                "<BASEFONT COLOR=#FFFFFF>" +
                "These are the abilities that the berserker learns as they level up:<br><br>" + 

                "Rage, Level 1<br>" +
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
            else if ( type == AscensionType.Archmage)
            {
                return 
                "<BASEFONT COLOR=#FFFFFF>" +
                "These are the abilities that the Archmage learns as they level up:<br><br>" + 

                "Arcane storm, level 1<br>" +
                "command: [ArchmageArcaneStorm <br>" +
                "The archmage unleashes (6 + 1 per 3 archmage levels) energy missiles at the target, each missile causes 10-18 + (int/25 + level/3) damage.<br>" + 
                "Casting this spell costs 45 mana, and once used, it cannot be used again for (45-1/level) seconds.<br>" +
                "level 10; a target hit by an arcane storm has a 3% chance per level of the archmage to receive a -(8 + level/4) energy resistance debuff.<br>" + 
                "that lasts for 12 + archmage level /2 seconds.<br>" + 
                "level 15: a target hit by an arcane storm loses 34 + level/2 stamina after being hit by a missile storm.<br>" + 
                "level 20: if a target is killed by an arcane storm, the cooldown on Conflux is set to zero.<br><br>" +  

                "Conflux, level 6<br>" + 
                "command: [ArchmageConflux <br>" + 
                "when activated, the archmage's spell damage is increased by 10% for (10 +1/level) seconds, 2 minutes cooldown.<br>" + 
                "level 12: the spell damage is increased by 15%.<br><br>" +

                "Mana Singularity, level 11.<br>" +
                "command: [ArchmageMassSingularity <br>" +
                "The Archmage creates a collapsing arcane vortex at a target location within 2 + (level/3) tiles. After 2.5 seconds, the singularity<br>" + 
                "explodes, causing 25-40 + (int/10 + level/2) energy damage to all hostile targets up to 2 tiles away from the source point.<br>" + 
                "Targets caught in the explosion also lose 20+level mana. The archmage recovers 4 mana per enemy hit. Activating this ability costs 50 mana.<br>" +
                "This ability has a cooldown of 60 seconds.<br>" + 
                "Level 16: all enemies hit by this ability are paralyzed for 4 seconds, and lose 20+level stamina.<br><br>" +

                "Timestop, level 18<br>" +
                "command:[ArchmageTimestop <br>" +
                "all hostile creatures up to (3+(level/5)) tiles away from the caster are paralyzed for (12+level/4) seconds.<br>" +
                "This ability costs 60 mana and has a 3 minutes cooldown.<br>" +
                "Level 20: once the paralyze ends, all enemies hit by this ability lose 40+level mana and stamina.<br><br>" +

                "mana vault, level 2<br>" +
                "when an enemy would leech or drain mana from the archmage, there's a 2% chance per level that the mana in immediately refunded to the  archmage<br>" +
                "Level 5: when an enemy would leech or drain mana from the archmage, they receive 15-25 + (level/2) energy damage<br>"+
                "Level 13: when an enemy would leech or drain mana from the archmage, they are paralyzed for 2 seconds<br><br>"+

                "weave reflection, level 8<br>"+
                "- the archmage receives a 2.5%/level chance of reflecting spells<br>"+
                "Level 17: when the archmage reflects a spell, they have a 1% chance / level of setting the cooldown on Conflux to zero<br>"+

                "arcane tempest, level 14<br>"+
                "when casting a spell at a hostile target, there's a (0.25 * level)% chance of triggering a Mana singularity at the target that costs<br>"+
                " no mana and doesn't have a cooldown.<br>"+
                "-Level 19: when arcane tempest triggers, there's a 1% chance/level that the cooldown on arcane storm is set to zero.<br><br>"+

                "Weave Unraveling, level 20<br>"+
                "when casting a harmful magery spell at a target, there's a 0.25% chance per level of creating weave disruptions around it.<br>"+ 
                "The amount of disruptions varies between 6-12, and they last from 12 to 22 seconds.<br>"+ 
                "Anyone standing on top of these disruptions receives 14-22 + (int/15) energy damage per second.<br>"+ 
                "</BASEFONT>";  
            }
            else if ( type == AscensionType.Archmage)
            {
                return
                "<BASEFONT COLOR=#FFFFFF>" +
                "These are the abilities that the Archmage learns as they level up:<br><br>" + 
                "Undying hordes, level 1<br>" + 
                "command: [PalemasterUndyingHordes<br>" + 
                "The Palemaster calls forth a mindless horde of undead to attack their enemies.<br>" + 
                "These will attack anything hostile to the caster relentlessly until they are destroyed or until they crumble into dust. <br>" + 
                "The Undying hordes has a 4 minutes cooldown between uses.<br>" +    
                "The horde lasts for 60 (+3 per level) seconds and its composition is based on the Palemaster Level.<br>" +  
                "Level 1-4: 3-5 skeletons, 2-3 skeleton warriors<br>" + 
                "Level 4-8: 3-5 skeletons, 2-3 skeleton warriors, 1-2 skeleton knights<br>" + 
                "Level 8-12: 3-4 skeleton warriors, 2-3 skeleton knights, 1-2 mummies<br>" + 
                "Level 13-16: 2-3 skeleton knights, 2-3 mumies, 1-2 ancient mummies, 1 undead giant<br>" + 
                "Level 17-19: 3-4 undead giants, 2-3 ancient mummies, 1 skeletal dragon<br>" + 
                "Level 20: 4-5 undead giants, 3-4 ancient mummies, 1-2 skeletal dragons<br><br>" +          

                "Enervate, level 6<br>" + 
                "command: [PalemasterEnervate<br>" + 
                "The palemaster syphons life from their enemies, feeding himself and enfeebling them.<br>" +  
                "When cast, this spell causes all hostile living creatures in up to 3 + (1 per 5 levels) tiles receive 40 + (level /3 ) cold damage and lose the same amount in mana.<br>" +  
                "For every creature hit, the palemaster recovers 5 hit points and 5 mana, to a maximum of 50 of each.<br>" + 
                "Creatures hit also receive -(5 + palemaster level / 4)% on their strength and dexterity for 30 seconds.<br>" +
                "This ability costs 30 mana to activate and has a one minute cooldown.<br>" + 
                "Level 12: the maximum amount recovered is capped at 100 for hit points and mana.<br><br>" +         

                "Circle Of Death, level 11.<br>" +
                "command: [PalemasterCircleOfDeath.<br>" +
                "The palemaster corrupts the weave to erode life from their enemies.<br>" +
                "This ability creates a circle arount the target creature, and all living creatures up to 2 (+1 per 5 levels) of it receive 12-18 + (level /2 ) + (int / 20) cold damage per second for an amount of seconds equal to 3 + level / 4.<br>" +
                "This ability has a 2 minutes cooldown and costs 60 mana to activate.<br>" +
                "Level 16: creatures caught in the circle lose stamina every second equal to half the damage dealt.<br><br>" +            

                "Danse Macabre, level 18.<br>" +
                "The Palemaster shatters the gate between words, bringing the ever hungry hordes to the land of the living.<br>" + 
                "This ability has a 4 minutes cooldown and costs 80 mana to activate.<br>" +
                "Every second for level/3 seconds, one of those happens:.<br>" +
                "    - 1-2 undead giants are spawned and attack the enemies of the pale master, they last for 30 seconds.<br>" + 
                "    - 2-3 mummy lords are spawned and attack the enemies of the pale master, they last for 30 seconds.<br>" +
                "    - every undead under the palemaster's control that is up to 5 tiles away from the palemaster heals an amount of hit points equal to 25% of their maximum hit points.<br>" +
                "    - the palemaster heals to full health.<br>" +
                
                "at level 20, these effects are added to the possible effects that happen every second:.<br>" +
                "    - every hostile living creature that is up to 3 tiles away from the palemaster and that is at less than 50% of their maximum hit points loses 10% of their hit points.<br>" +
                "    - all living creatures up to 4 tiles away from the pale master receive a -20% debuff to their strenght that lasts for 30 seconds.<br>" +
                "    - 1 skeletal dragon spawns and attack the enemies of the pale master, it lasts for 30 seconds.<br><br>" +

                "deathless vigor, level 2.<br>" +
                "When casting an offensive necromancy spell, 1.5% per level chance of recovering 2 + (level / 2) hit points.<br>" + 
                "Level 5: 0.25% per level chance of gaining +10% spell damage for 15 seconds.<br>" +
                "Level 13: the spell damage bonus increases to +15%, the duration increases to 25 and the chance increases to 0.45% per level.<br><br>" +

                "undead graft, level 8.<br>" +
                "When casting an offensive necromancy spell while wearing a full set of bone armor, there's a 0.25% per level chance all friendly summoned undead creatures will heal 5% of their hit points.<br>" +
                "Level 17: when undead graft triggers, friendly summoned undead cretures recover 2% of their maximum health per second for level/2 seconds.<br>" + 
            
                "creeping cold, level 14.<br>" +
                "When casting wither, there's a 0.25% chance per level that it will trigger an additional time.<br>" +
                "Level 19: when the creeping cold effect triggers, there's a 0.25% chance per level that enervate will be cast automatically ignoring mana costs and cooldown.<br>" +
            
                "herald of hereafter, level 20.<br>" +
                "When casting a harmful necromancy spell at a target, there's a 0.25% chance per level of creating weave disruptions around it. The amount of disruptions varies between 6-12, and they last from 12 to 22 seconds.<br>" +
                "Anyone standing on top of these disruptions receives 14-22 + (int/15) poison damage per second.<br>"+ 

                "</BASEFONT>"; 
            }
            else
            {
                return "No abilities defined.";                
            }
        }

    }
}
