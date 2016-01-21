using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class ControllerThread
    {
        public void Start()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            while (!globalParameters.ControllerPriority) ;

            string userInput = Console.ReadLine();
            CheckUserInput(userInput);

            globalParameters.ViewerPriority = true;
        }

        private void CheckUserInput(string userInput)
        {
            if (string.Equals(userInput.ToUpper(), "Q"))
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                globalParameters.MainThreadRuns = false;
            }
        }
    }
}
