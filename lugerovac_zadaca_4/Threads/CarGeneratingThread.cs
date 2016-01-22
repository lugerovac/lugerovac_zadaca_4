using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class CarGeneratingThread
    {
        Randomizer rnd;
        CarProvider carProvider;

        public CarGeneratingThread()
        {
            rnd = Randomizer.GetInstance();
            carProvider = CarProvider.GetInstance();
        }

        public void Start()
        {
            while(true)
            {
                Sleep();
                Automobile car = carProvider.GiveFreeCar();
                if (car == null)
                    continue;

                Parking parking = Parking.GetInstance();
                Zone[] AvailableZones = parking.GetParkingZones();
                int rnd2 = rnd.GetValue(0, AvailableZones.Length);
                int chosenZone = rnd2;
                bool reserved = parking.ReservePlaceInZone(car, AvailableZones[chosenZone]);
                if (reserved)
                {
                    car.Park();
                }
                else
                {
                }
            }
        }

        

        private void Sleep()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ArgumentHolder arguments = globalParameters.ArgumentHolder;
            Thread.Sleep(((arguments.TimeUnit * 1000) / arguments.IntervalOfArrivals) * (rnd.GetValue(1, 30) / 10));
        }
    }
}
