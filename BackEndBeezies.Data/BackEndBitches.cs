using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBeezies.Data
{
    public class BackEndBitches
    {
        private static Dictionary<string, string> Bitches;

        public BackEndBitches()
        {
            if (Bitches == null || Bitches.Count == 0)
            {
                AssembleBitches();
            }
        }

        private void AssembleBitches()
        {
            Bitches = new Dictionary<string, string>();
            Bitches.Add("Jeremy", "El Papi Chulo");
            Bitches.Add("MyLinh", "The Boss");
            Bitches.Add("Sonny", "The Shocker");
            Bitches.Add("Alexa", "The White Girl");
            Bitches.Add("Andres", "Senor Brito");
            Bitches.Add("Adan", "The Lagger");
            Bitches.Add("Tiana", "Fuck-That-Shit Girl");
            Bitches.Add("Jae", "J.Baby");
        }

        public List<string> GetBitches()
        {

            List<string> listBitches = new List<string>();
            foreach (var e in Bitches)
            {
                listBitches.Add(e.Key);
            }

            return listBitches;
        }

        public int CountBitches()
        {
            return Bitches.Count;
        }

        public List<string> GetMaleBitches()
        {
            List<string> boys = new List<string>();
            foreach(string name in Bitches.Keys)
            {
                if(name == "Jeremy" || name == "Adan" || name == "Sonny" || name == "Andres" || name == "Jae")
                {
                    boys.Add(name);
                }
            }
            return boys;
        }

        public List<string> GetFemaleBitches()
        {
            List<string> girls = new List<string>();
            foreach (string name in Bitches.Keys)
            {
                if (name == "MyLinh" || name == "Tiana" || name == "Alexa")
                {
                    girls.Add(name);
                }
            }
            return girls;
        }

        public bool DoesBitchExist(string name)
        {
            bool result = false;

            foreach (string e in Bitches.Keys)
            {
                result = (e.ToLower().Equals(name.ToLower())) ? true : false;
            }

            return result;
        }

        public string GetNickNameFor(string name)
        {
            string nickname = null;
            DoesBitchExist(name);

            if (!DoesBitchExist(name))
            {
                nickname = "They're not fam.";
            }
            foreach (var n in Bitches)
            {
                if (name.ToLower().Equals(n.Value.ToLower()))
                {
                    nickname = n.Value;
                }
            }
            return nickname;
        }
    }
}
