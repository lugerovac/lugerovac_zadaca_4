﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    static class MainFacade
    {
        public static bool InitializeArguments(string[] args)
        {
            if(args.Length < 10)
            {
                Console.WriteLine("Nedovoljan broj argumenata!");
                return false;
            }

            string result1 = ArgumentReader.ReadArguments(args);
            if(string.Equals(result1, "ERROR"))
            {
                Console.WriteLine("Argumenti nisu uspješno učitani!");
                return false;
            }
            PrintArguments();

            return true;
        }

        private static void PrintArguments()
        {
            GlobalParameters arguments = GlobalParameters.GetInstance();
            Console.WriteLine("Broj automobila: " + arguments.ArgumentHolder.CarNumber);
            Console.WriteLine("Broj zona: " + arguments.ArgumentHolder.ZoneNumber);
            Console.WriteLine("Kapacitet zone: " + arguments.ArgumentHolder.ZoneCapacity);
            Console.WriteLine("Max. parking: " + arguments.ArgumentHolder.MaxParkings);
            Console.WriteLine("Vremenska jedinica: " + arguments.ArgumentHolder.TimeUnit);
            Console.WriteLine("Interval dolaska: " + arguments.ArgumentHolder.IntervalOfArrivals);
            Console.WriteLine("Interval odlaska: " + arguments.ArgumentHolder.IntervalOfDepartures);
            Console.WriteLine("Cijena jedinice: " + arguments.ArgumentHolder.UnitPrice);
            Console.WriteLine("Interval kontrole: " + arguments.ArgumentHolder.ControlInterval);
            Console.WriteLine("Kazna parkiranja: " + arguments.ArgumentHolder.ParkingFine);
        }
    }
}