using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class Parking
    {
        private static Parking instance;
        private Monitor monitor;
        private Zone[] zones;

        protected Parking()
        {
            monitor = new Monitor();
        }

        public static Parking GetInstance()
        {
            if (instance == null)
                instance = new Parking();
            return instance;
        }

        public void InitializeZones(int numberOfZones, int zoneCapacity, int parkingTime, int timeUnit)
        {
            zones = new Zone[numberOfZones];
            for(int i = 1; i <= numberOfZones; i++)
            {
                zones[i-1] = new Zone(i, zoneCapacity, parkingTime, timeUnit);
            }
        }

        public Zone[] GetParkingZones()
        {
            return zones;
        }

        public bool ReservePlaceInZone(Automobile car, Zone zone)
        {
            monitor.Check();

            bool returnValue;
            if (zone.IsFull())
                returnValue = false;
            else
            {
                zone.Add(car);
                returnValue = true;
            }

            monitor.Release();
            return returnValue;
        }
    }
}
