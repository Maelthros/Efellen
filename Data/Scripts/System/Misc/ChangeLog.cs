using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using Server.Targeting;
using System.Collections.Generic;
using Server.Items;
using Server.Spells.Fifth;
using System.IO;
using System.Xml;

namespace Server.Misc
{
    class ChangeLog
    {
		public static string Version()
		{
			return "Version: Lolth's Gift (6th of June 2026)";
		}

		public static string Versions()
        {
			string versionTEXT = ""

       
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        +"Wrath of Ashardalom - Xth of Y of Z<BR>"
		+" <BR>"
		+"  * Progression, game balance & Systems:<BR>"
		+"• Hunter's mark system:"
		+"  • Added the [HuntersMark command, which allows for skilled trackers to gain a damage bonus against their prey based on their skill level.<BR>"
		+"  • When Hunter's Mark is active on a target, the tracker can raise its tracking skill by hitting it. Hunter's mark has a 1 minute cooldown between uses, and can also be triggered by regular use of the tracking skill.<BR>"
		+"• Various spells from unlockable classes (mystic, death knight, holy priest, shinobi) have been buffed and rebalanced.<BR>"
		+"• Slayer spellbooks and ranged weapons now add 70% base damage (down from 100%).<br>"
		+"• Added missing special attacks to Khumash Gor.<br>"
		+" <BR>"
		+"  * Items and crafting:<BR>"
		+"• Added various new artifacts as boss reward and global drops / sage quest rewards.<BR>"
		+"• Carpenters can now craft lockpicking training boxes.<br>"
		+" <BR>"
		+"  * Quality of Life:<BR>"
		+"• spellbooks for mages, necromancer and elementalists and songbooks now have a 'setup' context menu entry which will auto-collect missing scrolls from the player's inventory and add them to the book.<BR>"
		+" <BR>"

		+ sepLine()

		+"Lolth's Gift - 6th of June of 2026<BR>"
		+" <BR>"
		+"  * New Bosses were added to various regions of the game:<BR>"
	    +"Lolth's Gift - 6th of June of 2026<BR>"
        +" <BR>"
        +"	* New Bosses were added to various regions of the game:<BR>"
		+"• Each boss can drop drop themed and powerful items, skill scrolls and a variety of treasure.<BR>"
		+"• Bosses are divided in tiers which represent their general difficulty and the rewards for defeating them.<BR>"
		+"  • Tier 1 (Solo-friendly bosses for estabilished adventurers):<BR>"
        +"• Mother Superior defends her convent east of the city of Gray.<BR>"
		+"• Blacktooth the Trollbear raids southern Sosarian caravans in the forests around Montor.<BR>"
		+"• The Butcher has been brought into the service of the mad mages of Ravendark.<BR>"
        +"  • Tier 2 (Solo/Small Group bosses):<BR>"
		+"• Firefang the Warchief is setting the countryside near the city of Moon ablaze.<BR>"			
        +"• Spore Mother commands psychic forces in the Myconid Caves, in the eastern Sosaria mainland.<BR>"
		+"• Fiorin the Archdruid leads his pack in the defense of the Howling Grove.<BR>"
		+"• Black Phillip gathers his covenant on the Dread Islands.<BR>"
		+"  • Tier 3 (Challenging bosses designed for groups or very powerful adventurers): <BR>"
		+"• Caelan the Dread Knight broods in his keep as the blood pours from their victims.<BR>"
		+"• Hrimah, Fist of the North, rules the Glacial Scar from deep withing the fortress.<BR>"
		+"• The Daughter of Fire claims residence in the fires of Hell.<BR>"
		+"• The Skeleton King has awoken in the Ancient Pyramid, and his court has answered his call.<BR>"
		+"  • Tier 4 (Powerful group bosses): <BR>"
		+"• Bal Tsareth's ghost haunts her sanctum once more, after an expedition disturbed her rest.<BR>"
		+"• The Dreamweaver threatens Lodoria from its lair, deep within a cave whose very walls were driven to madness.<BR>"
		+"• Old One Eye roams the Savage Empire wastes, undisputed amongst the predators of that forsaken land.<BR>"
		+"• Fateweaver serves her queen in the glistering caves of Fanaedar.<BR>"
		+"• Xyrtaxis, Dean of Black Arts, teaches in Fanaedar's Arcane Academy.<BR>"
		+"• Annath, Shroud of the Lightless, preaches Lolth's mysteries in Fanaedar.<BR>"
		+"• Waervaerendor and Voaraghamanthar, the twin black dragons, now lead the cult at the temple of Osirus.<BR>"
		+"  • Tier 5 (for very optimized groups): <BR>"
		+"• Teel Fanae rules the city of the spider queen with an iron fist.<br> "
		+"• The Prince of Darkness holds court in Ravendark (RIP Ozzy).<BR>"
		+"• The Heavenly Marshall protects southern Sosaria from castle Griffin's Roost.<BR>"
		+"• The Herald of Cinders watches over his brood in Destard.<BR>"
		+"  • Tier 6+ (for groups of masochists:)<BR>"
		+"• The Queen of the Demonweb pits is lonely and would love some company.<BR>"
		+" <BR>"
        +"  * Crafting Overhaul:<BR>"
		+"• Crafting bonuses from different materials have been completely rebuilt for more streamlined progression and less property bloat.<BR>"
		+"• Exceptional Armor resistances significantly reduced.<BR>"
		+"• Carpenter-made armor now always has the Mage Armor property.<BR>"
		+"• Removed all alien crafting materials.<BR>"
		+"• Crafted clothing inherits the used fabric's hue.<BR>"
        +" <BR>"
		+"  * Artifacts:<BR>"
		+"• All artifact weapons now feature impactful special attacks (summons, AoE explosions, DoTs).<BR>" 
		+"• Artifact bonuses were adjusted to complement special effects.<BR>"
        +"• Skill bonuses on artifacts are more rare and specialized.<BR>"
		+"• Many redundant artifacts were removed.<BR>"
		+"• All weapon bases should now have an artifact weapon or two.<BR>"
		+"• Added new artifacts as boss drops, mark rewards, and global drops.<BR>"
		+"• The interface of sage quest search books and titan legendary artifacts has been refactored to cause less misery.<BR>"
		+" <BR>"
        +"  * Customization:<BR>"
		+"• Settings file significantly streamlined, in order to reduce the odds of the developer having an early stroke.<BR>"
		+" <BR>"
        +"  * NPCs:<BR>"
		+"• Oliver (south of Britain) trades rewards for Gender Change potions.<BR>"
		+"• Added around 400 new NPC dialogue lines.<BR>"
		+"• Training NPCs now teach skills to 50 (up from 32).<BR>"
		+"• Exodus no longer auto-deletes attacking pets.<BR>"
		+"• Beholders are now rarer, stronger, with dangerous eyestalk attacks.<BR>"
		+"• Many unique enemies gained dynamic special attacks.<BR>"
		+"• Enemy rogues ow only steal gold (instead of random junk from your bags).<BR>"
		+"• Enemy spellcasters overhauled with class-based spell lists (about 100 new D&D 3.5 spells were ported in to the game):<BR>"
		+"  • Druids summon animals, Mages cast arcane spells, Clerics smite and heal, Bards debuff and so on.<BR>"
		+"• Most spellcasters no longer heal to full upon defeat.<BR>"
		+" <BR>"
		+"  * Progression & Systems:<BR>"
		+"• Ascensions have been added to the game. This system adds many new classes and abilities and a new form of progression for powerful characters.<br>"
	    +"  • Ascensions level up as you defeat enemies while they are active. As a character levels in an ascension, they will gain up to 4 active and 4 passive abilities. Ascensions can go up to level 20.<br>"
		+"  • A character can have multiple ascensions, but only one can be active at a time.<br>"
		+"  • use [Ascension to see a list of currently available options, their requirements and benefits.<br>"
		+"  • the followign ascensions are implemented currently: Arcane Archer, Archmage, Assassin, Berserker, Blackguard, Crusader, Hierophant, Kensai, Palemaster, Reaver, Skald.<br>"
		+"• Tome of Power and Tome of Ascension were added to mark vendors (2000 marks each for unlimited storage of their scroll type).<BR>"
		+"• An endgame Weapon Enchanting System has been added to Fanaedar: It requires you to trade 20 Essence of Lolth's Hatred at the sacrificial pit to enhance artifact weapons, at a high cost for yourself.<BR>"
		+"• Orbs of the Demonweb Pits can be found in their namesake dungeon. They can add 25 enchantment points to regular and legendary artifact armor and clothing.<BR>"
		+"• Marks of The Weave: Mages Guild reward currency from defeating spellcasters and researching tomes.<BR>"
		+"• Marks of Devotion: Healers Guild reward currency from slaying undead and healing at House of Holy Mercy.<BR>"
		+"• Marks of the Wilds: Druids Guild reward currency from adventuring with pets, taming contracts, and Howling Grove meditation.<BR>"
		+"• Druid Archetype Expansion:<BR>"
		+"  • High-skill druids gain venom immunity.<BR>"
		+"  • Wildshape system: Meditate at Howling Grove for a chance of aqquiring a 'Heart of the Wilds', which is a talisman used to shapeshift.<BR>"
		+"    • Unlock forms through study, combat, or pet companionship.<BR>"
		+"    • Shapeshifted characters cannot use non-elementalist magic or wear metal armor.<BR>"
		+"    • Each form has unique special attacks and skill requirements (Spiritualism/Druidism, sometimes third skill).<BR>"
		+"• AoE spells (Elemental Devastation, Apocalypse, Fall, Chain Lightning, Meteor Swarm) no longer hit party members; multi-target damage scaling fixed.<BR>"
		+"• All guild rings now grant 30 skill points; some bonuses adjusted for thematic consistency.<BR>"
		+"• Ninjitsu damage bonus now applies only to fencing weapons<BR>."
		+"• Karma-warping traps reset karma to zero (instead of inverting it).<BR>"
		+"• Poison system changes:<BR>"
		+"  • Maximum weapon poison charges: 25.<BR>"
		+"  • Poisoning skill grants up to 25% chance to preserve charges on hit.<BR>"
		+"  • Highly skilled poison-users can now inflict a penalty to the poison resist of targets.<BR>"
		+"• Logout timer reduced to 30 seconds (down from 5 minutes).<BR>"
		+"• Taming contract rewards rebalanced and no longer generate incredibly ugly pets.<BR>"
		+"• Mark vendors now have 'Rewards' context menu for eligible players.<BR>"
		+"• Added the [SkillDrop command, which allows players to reduce their skills on demand.<BR>"
		+ "<BR>"
		+"  * Locations:<BR>"
		+"• Bloodstone Keep (Sosaria) replaces one of the Orc Camps in Sosaria as a high-level enemy fortress.<BR>"
		+"• Dardin's Pit (Sosaria) expanded with new rooms, rebuilt spawn pool, and miniboss.<BR>"		
		+"• Fanaedar (Underworld): Massive endgame Drow city with unique loot pool and 4 group bosses.<BR>"
		+"• Demonweb Pits (Underworld): Home of the spider queen herself, designed for the bravest of the brave.<BR>"
		+"• Sunless Citadel (Sosaria): Entry-level location for post-newbie dungeon characters, inspired by D&D 3E module, with a miniboss.<BR>"
		+"• Hive of the Eye Tyrant (Lodoria): Difficulty dungeon hidden in one of the caves in Lodoria.<BR>"
		+"• Castle Griffin Roost (Southern Sosaria): Lawful knights challenge evil adventurers in this keep.<BR>"
		+"• Myconid Caves (Eastern Sosaria): Small cave overgrown with mushrooms.<BR>"
		+"• Howling Grove (Western Sosaria): Druid sanctuary with wolf spirits.<BR>"
		+"• House of Holy Mercy (Sosaria): Hospital/convent for healing skill training and patient care.<BR>"
		+"• Destard: Has a new arena with a powerful boss to fight, its spawns were rebalanced and its difficulty increased to Hard.<BR>"
		+"• All easy dungeons gained an extra room with tougher enemies and now have condensed spawn pools.<BR>"
		+"• Mage Apprentices added to newbie dungeons to assist with spellbooks and teach caster combat.<BR>"
		+"• Fires of Hell: Doubled in size with new inhabitants, special flaming weapon drops, and two minibosses.<BR>"
		+"• Ancient Pyramid: Major internal and external redesign, new inhabitants and miniboss and many new challenges.<BR>"
        +"• Library of Bal Tsareth (formerly 'Clues'): Rebuilt mob pool, encounters, and lore with new quest from expedition leader.<BR>"
		+" <BR>"
        + sepLine()

			+ "";

			return versionTEXT;
		}

		public static string sepLine()
		{
			return "---------------------------------------------------------------------------------<BR><BR>";
		}
	}
}