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
                    "In order to activate this Ascension, you need to have 95 base skill in Tactics, camping and Magic Resist. Every time you level up the class, the requirement also increases by 1.<br><br>" +
                    "So a level 20 Berserker cannot activate this ascension unless they have 115 base skill in Tactics, camping and Magic Resist.<br><br>"+
                    "Berserkers also require their spirit to be free of the taint of civilization - a Berserker will not gain experience in this Ascension if they have learned Bushido, Knightship, Magery or Necromancy";
                case AscensionType.Archmage:
                    return
                    "The Archmage is a master of the Arcane. In combat, they control their opponents and execute powerful spells to bend the Weave itself to their will itself.<br><br>" +
                    "In order to activate this Ascension, you need to have 95 base skill in Magery, inscription and Psychology. Every time you level up the class, the requirement also increases by 1.<br><br>" +
                    "So a level 20 Archmage cannot activate this ascension unless they have 115 base skill in Magery , inscription and Psychology<br><br>"+
                    "Archmages also require a singular focus on arcane magic, and they will not gain experience in this class if they have learned Knightship, Elementalism, Necromancy or Bushido";
                case AscensionType.Palemaster:
                    return
                    "The Palemaster is death made flesh. In combat, they control an army of undead and curse and enfeeble their opponents until they have met their end.<br><br>" +
                    "In order to activate this Ascension, you need to have 95 base skill in Necromancy, forensics and Spiritualism. Every time you level up the class, the requirement also increases by 1.<br><br>" +
                    "So a level 20 Palemaster cannot activate this ascension unless they have 115 base skill in Necromancy, forensics and Spiritualism<br><br>"+
                    "Palemasters also are required to revel in death and vileness, and they will not gain experience in this class if they have learned Knightship, Elementalism or Bushido, or if they stray from the path of evil";
                case AscensionType.Crusader:
                    return
                    "The Crusader is the embodiment of virtue. In combat, they stand tall in defiance against evil.<br><br>"+
                    "In order to activate this Ascension, you need to have 95 base skill in Knightship, spiritualism and Tactics. Every time you level up the class, the requirement also increases by 1.<br><br>"+
                    "So a level 20 Crusader cannot activate this ascension unless they have 115 base skill in Knightship, spiritualism and Tactics.<br><br>"+
                    "Crusaders also are required to follow the path of justice and uphold good, and they will not gain experience in this class if they have learned Bushido, Necromancy or Forensics, or if they stray from the path of good.<br><br>";
                case AscensionType.Assassin:
                    return
                    "The Assassin is an expert in ending lifes prematurely. In combat, they employ poisons to great effect to hinder and annihilate their foes.<br><br>"+
                    "In order to activate this Ascension, you need to have 95 base skill in both Poisoning, hiding and Fencing. Every time you level up the class, the requirement also increases by 1.<br><br>"+
                    "So a level 20 Crusader cannot activate this ascension unless they have 115 base skill in both Poisoning, hiding and Fencing.<br><br>"+
                    "Assassins also are required to abandon their morals, and they will not gain experience in this class if they have learned Bushido or knightship, or if they abandon the path of evil.";   
                case AscensionType.Blackguard:
                    return
                    "The Blackguard is a champion of evil and corruption. In combat, they are juggernauts that bring frost e blood into the battlefield.<br><br>"+
                    "In order to activate this Ascension, you need to have 95 base skill in Knightship, Arms lore and Necromancy. Every time you level up the class, the requirement also increases by 1.<br><br>"+
                    "So a level 20 Crusader cannot activate this ascension unless they have 115 base skill in Knightship, Arms lore and Necromancy.<br><br>"+
                    "Blackguardss also are required to abandon their morals, and they will not gain experience in this class if they have learned Bushido, spiritualism or elementalism, or if they abandon the path of evil.";
                default:
                    return "IN DEVELOPMENT.";
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
            else if ( type == AscensionType.Palemaster)
            {
                return
                "<BASEFONT COLOR=#FFFFFF>" +
                "These are the abilities that the Palemaster learns as they level up:<br><br>" + 
                "Undying hordes, level 1<br>" + 
                "command: [PalemasterUndyingHordes<br>" + 
                "The Palemaster calls forth a mindless horde of undead to attack their enemies.<br>" + 
                "These will attack anything hostile to the caster relentlessly until they are destroyed or until they crumble into dust. <br>" + 
                "The Undying hordes has a 3 minutes cooldown between uses.<br>" +    
                "The horde lasts for 60 (+3 per level) seconds and its composition is based on the Palemaster Level.<br>" +  
                "Level 1-4: 3-5 skeletons, 2-3 skeleton warriors<br>" + 
                "Level 5-8: 3-5 skeletons, 2-3 skeleton warriors, 1-2 skeleton knights<br>" + 
                "Level 9-12: 3-4 skeleton warriors, 2-3 skeleton knights, 1-2 mummies<br>" + 
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
                "command: [PalemasterDanseMacabre<br>"+
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
                "Level 17: when undead graft triggers, friendly summoned undead cretures recover 2% of their maximum health per second for level/2 seconds.<br><br>" + 
            
                "creeping cold, level 14.<br>" +
                "When casting wither, there's a 0.25% chance per level that it will trigger an additional time.<br>" +
                "Level 19: when the creeping cold effect triggers, there's a 0.25% chance per level that enervate will be cast automatically ignoring mana costs and cooldown.<br>" +
            
                "herald of hereafter, level 20.<br>" +
                "When casting a harmful necromancy spell at a target, there's a 0.25% chance per level of creating weave disruptions around it. The amount of disruptions varies between 6-12, and they last from 12 to 22 seconds.<br>" +
                "Anyone standing on top of these disruptions receives 14-22 + (int/15) poison damage per second.<br>"+ 

                "</BASEFONT>"; 
            }
            else if (type == AscensionType.Crusader)
            {
                return
                "<BASEFONT COLOR=#ffffff>"+
                "Smite, level 1.<br>" +
                "command: [CrusaderSmite<br>" +
                "The crusader channels its valor and calls forth an explosion of purifying flame.<br>" + 
                "This effect causes 20-32 +( level / 2 + str/15) damage to all evil creatures that are up to 2 (+1 per 5 levels) tiles away from the crusader.<br>" +
                "Smite costs 20 mana and 20 stamina to activate, and has a 1 minute cooldown.<br>" +
                "- Level 10: hostile creatures that have karma of -10k or lower are paralyzed for 4(+1 per 6 levels) seconds after being hit by the smite.<br>" +
                "- Level 15: friendly creatures with positive karma caught in the area of the smite are healed for 20 + level/2 hit points.<br>" +
                "- Level 20: hostile evil creatures that have karma of -10k or lower damaged by the smite are caught in searing flames. They receive 10-20 + str/15 fire damage every 2 seconds for 12 seconds.<br><br>" +

                "Charge, level 6.<br>" +
                "command: [CrusaderCharge<br>" +
                "When used, the character chooses a free tile that is at least 2 tiles away from them and its moved to that tile.<br>" +
                "The maximum range is equal to  3 + level/5. When arriving, every hostile creature adjacent to that tile has a 1% per level chance of being paralyzed for 3 seconds.<br>" +  
                "Has a cooldown of 9 seconds, minus one second per 3 crusader levels.<br>" +
                "- Level 12: when arriving, all hostile creatures adjacent to the destination square receive 30-45 + ((str / 15) + level / 3) physical damage.<br><br>" +

                "Aura of Hope, level 11.<br>" +
                "command: [CrusaderAuraOfHope<br>" +
                "When used, the crusader and all friendly creatures up to 4 tiles away from the crusader receive the following benefits:<br>" +
                "- they restore 12 + (crusader level / 2) hitpoints every 4 seconds per 30 seconds.<br>" +
                "- they restore 6 + (crusader level / 2) mana every 4 seconds per 30 seconds.<br>" +
                "- they restore 6 + (crusader level / 2) stamina every 4 seconds per 30 seconds.<br>" +
                "This skill has a 3 minutes cooldown, and costs 40 mana and 40 stamina to activate.<br>" +
                "- Level 16: creatures affected by the aura of hope are healed to full health once the buff expires.<br><br>" +

                "Heavenly Gate, level 18.<br>" +
                "command: [CrusaderHeavensGate<br>" +
                "The crusader opens the pearly gates and calls forth a celestial companion to aid them in their war against all evil.<br>" +
                "The creature is a powerful Archon that requires 2 control slots and remains at the crusader's site until defeated.<br>" +
                "Activating this ability costs 60 mana and 60 stamina. It has a 5 minutes cooldown.<br>" +
                "- Level 20: There's a 1% chance per level that two archons will be summoned instead.<br><br>" + 
            
                "Divine Grace, level 2.<br>" +
                "the crusader has a 4% chance per level chance of automatically healing from lesser, regular and greater poisons.<br>" + 
                "- Level 5:  the chance also applies to deadly poisons.<br>" +
                "- Level 13:  the chance also applies to lethal poisons.<br><br>" +

                "Holy Fervor, level 8.<br>" +
                "When the crusader kills a demon, they have a 1.5% per level chance of triggering an AoE explosion of holy fire, causing 20-32 + (level/2 + str/15) damage to all evil hostile creatures that are up to 2 (+1 per 5 levels) tiles away from the crusader.<br>" +
                "- Level 17: when Holy Fervor triggers, the Cooldown on Smite is set to zero.<br>" +
            
                "Inquisitorial Strikes, level 14.<br>" +
                "the crusader's melee weapon strikes cause + (level/2)% damage against demons.<br>" +
                "- Level 19: the crusader's melee weapon strikes cause + (level/4)% damage against evil creatures.<br>" +
            
                "Divine Judgement, level 20.<br>" +
                "When the crusader kills a powerful evil creature, there's a 2.5% chance that a strong creature called Luminar will be summoned to aid the Crusader on their war against evil.<br>" +
                " creature will attack any nearby opposing creature with great ferocity, and will remain in the material plane for one minute.<br>" +
                "</BASEFONT>";
            }
            else if (type == AscensionType.Assassin)
            {
                return
                "<BASEFONT COLOR=#ffffff>"+
                "Noxious Cloud, level 1.<br>" +
                "command: [AssassinNoxiousClou<br>" +
                "The assassin creates a cloud of foul vapors at target location that poisons all enemies caught in its area.<br>" +
                "The cloud inflicts greater poison on all affected enemies. This ability costs 30 mana and 30 stamina to activate.<br>" + 
                "This ability has a 1 minute cooldown. The are of the cloud is equal to 1 + 1 per 6 levels.<br>" +
                "- Level 10: The cloud inflics Deadly poison on all affected enemies.<br>" +
                "- Level 15: The cloud inflicts Lethal poison on all affected enemies.<br>" +
                "- Level 20: all affected enemies lose 20 poison resist for 30 seconds.<br><br>" +

                "Crippling poison, level 6.<br>" +
                "command: [AssassinCripplingPoison<br>" +
                "The assassin throws a vial of crippling poison at a target, inflicting deadly poison on it and preventing them from walking for level / 2 seconds.<br>" +
                "This ability costs 40 mana and 40 stamina to activate and has a 1 minute cooldown.<br>" +
                "- Level 12: The crippling poison is Lethal and affects all hostile creatures up to 2 tiles away from the original target.<br><br>" + 

                "Toxic surge, level 11.<br>" +
                "command: [AssassinToxicSurge<br>" +
                "For the next 30 seconds, the assassin causes + 10% damage bonus with weapon strikes against poisoned creatures.<br>" + 
                "This ability costs 40 mana and 40 stamina to activate and has a 2 minutes cooldown.<br>" +
                "- Level 16: When activated, there's a 1% chance per level of setting the cooldown on Noxious Cloud to zero.<br>" + 

                "Cleansing Annihilation, level 18.<br>" +
                "command: [AssassinCleansingAnnihilation<br>" +
                "The assassin inflicts lethal poison on the target, then immediately consumes all of its ticks.<br>" + 
                "If the target survives, all creatures around it to up to 3 tiles away are the inflicted with a lethal poison.<br>" + 
                "Activating this ability costs 50 mana and 50 stamina and it has a 4 minutes cooldown.<br>" +
                "- Level 20: when activating this ability, there's a 1% chance per level that the cooldown on toxic surge will be set to zero.<br><br>" +

                "Virulent Strikes, level 2.<br>" +
                "When applying a poison on a target with a strike, the assassin has a 1% per level chance of immediately resolving 1 poison tick.<br>" +
                "- Level 5: when making a weapon attack against a poisoned creature, the assassin has a 0.25% chance per level of immediately resolving a poison tick.<br>" +
                "- Level 13: when making a weapon attack against a poisoned creature, the assassin has a 0.12% chance per level of immediately resolving an additional poison tick.<br><br>" +

                "dangerous habits, level 8.<br>" +
                "increases tick damage of poisons inflicted by the assassin by 9%.<br>" +
                "- Level 17: increases tick damage of poisons inflicted by the assassin by 18%.<br><br>" +

                "Deadly Strikes, level 14.<br>" +
                "The assassin causes 9% more damage with attacks to poisoned creatures.<br>" +
                "- Level 19: attacks against poisoned creatures ignore 25% of the target's poison resistance.<br><br>" +

                "Terminal, level 20.<br>" +
                "When killing a poisoned creature, the assassin has a 0.25% chance per level of inflicting lethal poison on all hostile creatures that are up to 2 tiles away from it.<br>" +
                "</BASEFONT>";
            }
             else if (type == AscensionType.Blackguard)
            {
                return
                "<BASEFONT COLOR=#ffffff>"+
                "Dark Succor, level 1.<br>" +
                "command: [BlackguardDarkSuccor<br>" +
                "The blackguard enters an unholy trance for (30 +1 per level) seconds.<br>" +
                "Dark succor costs 20 mana to activate. While its active, the Blackguard has 15 + level/2 strength.<br>" + 
                "When Dark Succor ends, the blackguard loses half ot their remaining mana. This ability has a 90 seconds cooldown.<br>" +
                "- Level 10: While on the trance and under 50% of their maximum hitpoints, the blackguard causes + 0.75%  damage per level against positive karma creatures.<br>" +
                "- Level 15: While on the trance and under 50% of their maximum mana, whenever the blackguard kills a creature with a weapon strike, the blackguard recovers 2 + level/2 mana.<br>" + 
                "- Level 20: While on the trance amd imder 50% of their maximum hitpoints, whenever the blackguard kills a creature with a weapon strike, the blackguard heals for 6 + level/2 hit points.<br><br>" +

                "Death's Advance, level 6.<br>" +
                "command: [BlackguardDeathsAdvance<br>" +
                "When used, the blackguard chooses a free tile that is at least 2 tiles away from them and its moved to that tile. The maximum range is equal to  3 + level/5. When arriving, every hostile creature adjacent to that tile has a 1% per level chance of knockedback for 2 + 1 tile for every 5 levels of the blackguard.<br>" +  
                "Has a cooldown of 9 seconds, minus one second per 3 Blackguard levels.<br>" + 
                "- Level 12: when arriving, all hostile creatures adjacent to the destination square receive 30-45 + ((str / 15) + level / 3) physical damage<br><br>" +

                "Chains of Ice, level 11.<br>" +
                "command: [BlackguardChainsOfIce<br>" +
                "The blackguard throws icy chains around themselves, freezing all hostile creatures for 3 + 1  per 4 levels seconds. Creatures caught by the chains receive 30-43 + (str/15) cold damage.<br>" +
	            "costs 30 mana to activate and has a 90 seconds cooldown.<br>" +
                "- Level 16: When the paralyze ends, the chains explode causing an additional 30-43 + (str/15) cold damage at each creature adjacent to an affected creature.<br><br>" +

                "Frostwyrm's Fury, level 18.<br>" +
                "command: [BlackguardsFrostwyrmsFury<br>" +
                "The blackguard opens the netherworld gates and calls forth an undead dragon bound to his will.<br>" +
                "The creature is a powerful dracolich that requires 4 control slots and remains at the blackguard's side until defeated.<br>" + 
                "Activating this ability costs 60 mana and 60 stamina. It has a 5 minutes cooldown.<br>" +
                "- Level 20: there's a 1% chance per level that two frostwyrms will be summoned instead.<br><br>" + 

                "Frozen Heart, level 2.<br>" +
                "Increases the cold damage done by the blackguard's weapon strikes by 6%.<br>" +
                "- Level 5: Increases the cold damage done by the blackguard's weapon strikes by 12%.<br>" +
                "- Level 13:Increases the cold damage done by the blackguard's weapon strikes by 18%.<br><br>" +

                "Morbidity, level 8.<br>" +
                "When the blackguard kills a positive karma creature, they have a 0.25% chance per level of terrorizing most nearby foes that are up to 2 tiles away and making them flee for 3 seconds.<br>" + 
                "- Level 17: Terrorized enemies flee for 6 seconds instead.<br><br>" +

                "Merciless Strikes, level 14.<br>" +
                "The blackguard's weapon attacks have a 1% chance per level of affecting the target's weakest resistance.<br>" +
                "- Level 19: The blackguard's merciless strikes have a 0.25% chance per level of paralyzing the target for 3 seconds.<br><br>" +

                "Soul Reaper, level 20.<br>" +
                "When killing a hostile creature, the blackguard has a 0.25% chance per level of syphoning level + str /25 health from  all hostile creatures that are up to 2 tiles away from it.<br>" +
                "</BASEFONT>";
            }
            else
            {
                return "IN DEVELOPMENT.";                
            }
        }

    }
}
