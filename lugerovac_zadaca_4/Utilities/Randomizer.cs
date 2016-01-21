using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class Randomizer
    {
        private static Randomizer instance;
        private Random rnd;

        protected Randomizer()
        {
            rnd = new Random();
        }

        public static Randomizer GetInstance()
        {
            if (instance == null)
                instance = new Randomizer();
            return instance;
        }

        public int GetValue(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
