using System;
using System.Runtime.Serialization;


namespace Publisher
{
    public enum Materials { Plastic, Glass }

    [Serializable]
    [DataContract]
    public class Chars
    {
        [DataMember]
        public string Transparency;
        [DataMember]
        public string Energy;
        [DataMember]
        public decimal Alcohol;
        [DataMember]
        public decimal Spill;
        [DataMember]
        public Boolean Pitcher;
        [DataMember]
        public Materials Material;

        public Chars() { }

        public Chars(string transparency, string energy, decimal alcohol, decimal spill, bool pitcher, Materials material)
        {
            Transparency = transparency;
            Energy = energy;
            Alcohol = alcohol;
            Spill = spill;
            Pitcher = pitcher;
            Material = material;
        }

        public override string ToString()
        {
            string s = Transparency + " " + Energy + " " + Alcohol + " " + Spill + " " + Material + " " + Pitcher;
           
            return s;
        }
    }
}
