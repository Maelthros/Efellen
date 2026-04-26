using System;
using Server.Network;
using Server.Items;
using Server.Engines.Harvest;
using System.Net;

namespace Server.Items
{
	public class Artifact_EndOfHope : GiftScythe
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_EndOfHope()
		{
			Hue = 2310;
			Name = "End of Hope";
			ItemID = 0x2690;
			WeaponAttributes.HitLeechHits = 75;
			Attributes.SpellChanneling = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, "Culls souls." );
		}

		public override void OnHit(Mobile attacker, Mobile defender, double damage)
        {
            if (attacker == null || defender == null || attacker.Map == null || defender.Map == null || defender.Deleted || attacker.Deleted)
		        return;

            if (defender.Hits <= defender.Hits/10 && Utility.Random(100) < 15)
            {
                int hits = Utility.RandomMinMax(5, 25);
                int mana = Utility.RandomMinMax(5, 15);
                attacker.Hits += hits;
                attacker.Mana += mana;
                attacker.SendMessage(33, "Grim Reaper's Scythe devours the enemy's soul!");
            }
			base.OnHit(attacker, defender, damageBonus);
        }

		public Artifact_EndOfHope( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}