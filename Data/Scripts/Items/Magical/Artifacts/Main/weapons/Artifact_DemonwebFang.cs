using System;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;
using Server.Guilds;
using Server.EffectsUtil;

namespace Server.Items
{
	public class Artifact_DemonwebFang : GiftSai
	{
		private DateTime m_NextArtifactAttackAllowed;

		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_DemonwebFang()
		{
			Name = "Fang of the Demonweb";
			Hue = 0x922;
			WeaponAttributes.HitPoisonArea = 50;
			Attributes.SpellChanneling = 1;
			Attributes.BonusDex = 15;
			Attributes.AttackChance = 15;
			ArtifactLevel = 2;
			MinDamage = MinDamage + 12;
			MaxDamage = MaxDamage + 12;
			Server.Misc.Arty.ArtySetup( this, "Bears Lolth's treasonous kiss" );
			m_NextArtifactAttackAllowed = DateTime.MinValue;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = 0;
			cold = 0;
			fire = 0;
			nrgy = 0;
			pois = 100;
			chaos = 0;
			direct = 0;
		}

		public override bool OnEquip( Mobile from )
		{
			if ( from.Karma > -15000 )
			{
				from.SendMessage( 0x922, "Lolth's corruption strikes you down!" );

				from.Hits = 1;
				from.Mana = 1;
				from.Stam = 1;

				from.FixedParticles( 0x3709, 10, 30, 5052, 0x922, 0, EffectLayer.Waist );
				from.BoltEffect( 0 );
			}

			return base.OnEquip( from );
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			if ( attacker == null || defender == null )
				return;

			if ( attacker.Karma > -15000 )
			{
				attacker.SendMessage( 0x922, "Lolth's kiss burns your soul!" );

				attacker.Hits -= GetLossAmount( attacker.HitsMax, 5 );
				attacker.Mana -= GetLossAmount( attacker.ManaMax, 5 );
				attacker.Stam -= GetLossAmount( attacker.StamMax, 5 );

				if ( attacker.Hits < 1 )
					attacker.Hits = 1;

				if ( attacker.Mana < 1 )
					attacker.Mana = 1;

				if ( attacker.Stam < 1 )
					attacker.Stam = 1;

				attacker.FixedParticles( 0x3709, 10, 30, 5052, 0x922, 0, EffectLayer.Waist );
				attacker.BoltEffect( 0 );

				return;
			}

			if ( DateTime.Now < m_NextArtifactAttackAllowed )
				return;

			double chance = GetProcChance( attacker );

			if ( Utility.RandomDouble() > chance )
				return;

			m_NextArtifactAttackAllowed = DateTime.Now + TimeSpan.FromSeconds( 60.0 );

			int hitLoss = GetPositiveKarmaLoss( defender.Karma );
			int manaLoss = GetNegativeKarmaLoss( defender.Karma );

			bool fired = false;

			if ( defender.Karma >= 0 && hitLoss > 0 )
			{
				int amount = GetLossAmount( defender.HitsMax, hitLoss );

				defender.Hits -= amount;

				if ( defender.Hits < 1 )
					defender.Hits = 1;

				fired = true;
			}

			if ( defender.Karma < 0 && manaLoss > 0 )
			{
				int amount = GetLossAmount( defender.ManaMax, manaLoss );

				defender.Mana -= amount;

				if ( defender.Mana < 0 )
					defender.Mana = 0;

				fired = true;
			}

			if ( fired )
			{
				attacker.SendMessage( 0x922, "Lolth's caress cripples your foe!" );

				defender.FixedParticles( 0x3709, 10, 30, 5052, 0x922, 0, EffectLayer.Waist );
				defender.BoltEffect( 0 );
			}
		}

		private double GetProcChance( Mobile from )
		{
			double luckChance = 0.0;
			double fencingChance = 0.0;

			if ( from.Luck > 0 )
			{
				int cappedLuck = from.Luck;

				if ( cappedLuck > 2000 )
					cappedLuck = 2000;

				luckChance = (double)cappedLuck / 2000.0 * 0.025;
			}

			if ( from.Skills[SkillName.Fencing] != null )
			{
				double fencing = from.Skills[SkillName.Fencing].Base;

				if ( fencing > 125.0 )
					fencing = 125.0;

				fencingChance = fencing / 125.0 * 0.025;
			}

			return luckChance + fencingChance;
		}

		private int GetPositiveKarmaLoss( int karma )
		{
			if ( karma >= 15000 )
				return 10;

			if ( karma >= 12500 )
				return 8;

			if ( karma >= 10000 )
				return 6;

			if ( karma >= 5000 )
				return 4;

			if ( karma >= 1000 )
				return 2;

			if ( karma >= 0 )
				return 1;

			return 0;
		}

		private int GetNegativeKarmaLoss( int karma )
		{
			if ( karma <= -15000 )
				return 10;

			if ( karma <= -12500 )
				return 9;

			if ( karma <= -10000 )
				return 7;

			if ( karma <= -5000 )
				return 5;

			if ( karma <= -1000 )
				return 4;

			if ( karma < 0 )
				return 2;

			return 0;
		}

		private int GetLossAmount( int max, int percent )
		{
			int amount = (int)( (double)max * (double)percent / 100.0 );

			if ( amount < 1 )
				amount = 1;

			return amount;
		}

		public Artifact_DemonwebFang( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 1 );
			writer.Write( m_NextArtifactAttackAllowed );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			ArtifactLevel = 2;

			int version = reader.ReadEncodedInt();

			if ( version >= 1 )
				m_NextArtifactAttackAllowed = reader.ReadDateTime();
			else
				m_NextArtifactAttackAllowed = DateTime.MinValue;
		}
	}
}