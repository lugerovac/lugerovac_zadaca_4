using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public static class ArgumentReader
    {
        public static string ReadArguments(string[] args)
        {
            ArgumentHolder arguments = new ArgumentHolder();

            int[] resturnedResult = new int[10];
            int counter = 0;
            arguments.CarNumber = resturnedResult[counter] = CheckArgument(args[counter++], 10, 100);
            arguments.ZoneNumber = resturnedResult[counter] = CheckArgument(args[counter++], 1, 4);
            arguments.ZoneCapacity = resturnedResult[counter] = CheckArgument(args[counter++], 1, 100);
            arguments.MaxParkings = resturnedResult[counter] = CheckArgument(args[counter++], 1, 10);
            arguments.TimeUnit = resturnedResult[counter] = CheckArgument(args[counter++], 1, 10);
            arguments.IntervalOfArrivals= resturnedResult[counter] = CheckArgument(args[counter++], 1, 10);
            arguments.IntervalOfDepartures = resturnedResult[counter] = CheckArgument(args[counter++], 1, 10);
            arguments.UnitPrice = resturnedResult[counter] = CheckArgument(args[counter++], 1, 10);
            arguments.ControlInterval = resturnedResult[counter] = CheckArgument(args[counter++], 1, 10);
            arguments.ParkingFine = resturnedResult[counter] = CheckArgument(args[counter++], 10, 100);

            int index = 0;
            bool hasErrors = false;
            foreach(int result in resturnedResult)
            {
                index++;
                if(result == -1)
                {
                    Console.WriteLine(index.ToString() + ". argument nije unutar valjanih granica!");
                    hasErrors = true;
                } else if(result == -2)
                {
                    Console.WriteLine("Došlo je do pogreške tjekom učitavanja " + index.ToString() + ". argumenta!");
                    hasErrors = true;
                }
            }

            if (hasErrors)
                return "ERROR";

            GlobalParameters ah = GlobalParameters.GetInstance();
            ah.ArgumentHolder = arguments;
            return "OK";
        }

        private static int CheckArgument(string argument, int minValue, int maxValue)
        {
            int arg;
            try
            {
                arg = Int32.Parse(argument);
            }catch
            {
                return -2;
            }

            if (arg < minValue || arg > maxValue)
                return -1;
            else
                return arg;
        }
    }
}
