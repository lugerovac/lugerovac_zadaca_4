using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class ControllerThread
    {
        public void Start()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(10);
                }
                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                CheckUserInput(pressedKey);
            }
        }

        private void CheckUserInput(ConsoleKey userInput)
        {
            if(userInput == ConsoleKey.Q)
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                globalParameters.MainThreadRuns = false;
            }
        }
    }
}
