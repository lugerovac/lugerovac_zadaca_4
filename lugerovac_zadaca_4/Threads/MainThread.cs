using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class MainThread
    {
        public void Start()
        {
            GlobalParameters gp = GlobalParameters.GetInstance();
            gp.MainThreadRuns = true;
            while(true)
            {
                if (!gp.MainThreadRuns)
                    continue;

                Console.WriteLine("\nUpiši Q za prekid programa: ");
                string userInput = Console.ReadLine();
                if (string.Equals(userInput.ToUpper(), "Q"))
                    gp.MainThreadRuns = false;
            }
        }
    }
}
