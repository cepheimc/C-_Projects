using System;
using System.Runtime.Serialization;


namespace Publisher
{
    [Serializable]
    [DataContract]
    public class Ingredients
    {
        [DataMember]
        public bool Water, Sugar, Hop, Malt;

        public Ingredients() { }

        public Ingredients(bool water, bool sugar, bool hop, bool malt)
        {
            Water = water;
            Sugar = sugar;
            Hop = hop;
            Malt = malt;
        }

        public override string ToString()
        {
            string s = Water + " " + Sugar + " " + Hop + " " + Malt;
            
            return s;
        }
    }
}
