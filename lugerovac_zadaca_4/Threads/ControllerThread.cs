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
            
            if (userInput == ConsoleKey.D1 || userInput == ConsoleKey.NumPad1)
            {
                Parking parking = Parking.GetInstance();
                parking.Close();
            }

            if (userInput == ConsoleKey.D2 || userInput == ConsoleKey.NumPad2)
            {
                Parking parking = Parking.GetInstance();
                parking.Open();
            }

            if (userInput == ConsoleKey.D3 || userInput == ConsoleKey.NumPad3)
            {
                Parking parking = Parking.GetInstance();
                parking.CalculateBillProfits();
            }

            if (userInput == ConsoleKey.D4 || userInput == ConsoleKey.NumPad4)
            {
                Parking parking = Parking.GetInstance();
                parking.CalculateFineProfits();
            }

            if (userInput == ConsoleKey.D5 || userInput == ConsoleKey.NumPad5)
            {
                Parking parking = Parking.GetInstance();
                parking.ShowLostClientNumber();
            }

            if (userInput == ConsoleKey.D6 || userInput == ConsoleKey.NumPad6)
            {
                Parking parking = Parking.GetInstance();
                parking.ShowConscificatedNumber();
            }

            if (userInput == ConsoleKey.D7 || userInput == ConsoleKey.NumPad7)
            {
                Parking parking = Parking.GetInstance();
                parking.ShowBestClients();
            }

            if (userInput == ConsoleKey.D8 || userInput == ConsoleKey.NumPad8)
            {
                Parking parking = Parking.GetInstance();
                parking.ShowZoneAvailability();
            }
        }
    }
}
