using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;


namespace Publisher
{
    
        [Serializable]
        [XmlRoot("Beers")]
        [DataContract]
        public class Beers
        {
            [XmlElement("Beer")]
            [DataMember]
            public List<Beer> beers;

            public Beers()
            {
                beers = new List<Beer>();
            }
        }

        public enum TypeValues { Light, Dark, Live, Lager }

    [Serializable]
    [DataContract]
    public class Beer
    {
        [XmlAttribute] [DataMember] public int ID;

        [XmlElement(ElementName = "Name")] [DataMember]
        public string Name;

        [XmlElement(ElementName = "Type")] [DataMember]
        public TypeValues Type;

        [XmlElement(ElementName = "AI")] [DataMember]
        public Boolean Ai;

        [XmlElement(ElementName = "Manufacture")] [DataMember]
        public string Manufacture;

        [XmlElement(ElementName = "Chars")] [DataMember]
        public Chars Char;

        [XmlElement(ElementName = "Ingredients")] [DataMember]
        public Ingredients Ingredient;

        public Beer()
        {
        }

        public Beer(int id, string name, TypeValues type, bool ai, string manufacture, Chars c, Ingredients ingredient)
        {
            ID = id;
            Name = name;
            Type = type;
            Ai = ai;
            Manufacture = manufacture;
            Char = c;
            Ingredient = ingredient;
        }

    }
}
