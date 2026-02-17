using System;
using Server;
using Server.Items;
using Server.Custom.Ascensions;

namespace Server.Custom.Ascensions
{
    public class AscensionScroll : Item
    {
        private AscensionType m_Ascension;

        [CommandProperty(AccessLevel.GameMaster)]
        public AscensionType Ascension
        {
            get { return m_Ascension; }
            set { m_Ascension = value; InvalidateProperties(); }
        }

        [Constructable]
        public AscensionScroll(AscensionType type) : base(0x1F4C) // Scroll itemID
        {
            Weight = 0.2;
            LootType = LootType.Regular;
            m_Ascension = type;
            Stackable = true;
            Amount = 1;
            Name = type.ToString() + " Ascension Scroll";
        }

        public AscensionScroll(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add("Required for unlocking the " + m_Ascension.ToString() + " Ascension.");
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write((int)m_Ascension);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_Ascension = (AscensionType)reader.ReadInt();
        }
    }
}
