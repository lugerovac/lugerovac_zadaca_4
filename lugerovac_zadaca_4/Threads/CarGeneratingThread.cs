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
        private Automobile[] cars;
        private int numberOfCars;
        Randomizer rnd;

        public CarGeneratingThread()
        {
            GlobalParameters gp = GlobalParameters.GetInstance();
            rnd = Randomizer.GetInstance();
            numberOfCars = gp.ArgumentHolder.CarNumber;
            cars = new Automobile[numberOfCars];
            FillCars();
        }

        private void FillCars()
        {
            for(int i = 0; i < numberOfCars; i++)
            {
                cars[i] = new Automobile(i);
            }
        }

        public void Start()
        {
            while(true)
            {
                Sleep();
                Automobile car = getRandomCar();
                if (car == null)
                    continue;

                Parking parking = Parking.GetInstance();
                Zone[] AvailableZones = parking.GetParkingZones();
                int rnd2 = rnd.GetValue(0, AvailableZones.Length - 1);
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

        private Automobile getRandomCar()
        {
            int random = rnd.GetValue(0, numberOfCars - 1);
            int i = random;
            int limit = random - 1;
            if (limit < 0)
                limit = numberOfCars - 1;

            for(; ; i++)
            {
                if (i == cars.Length)
                    i = 0;
                if (!cars[i].IsParked())
                    return cars[i];
                if (i == limit)
                    break;
            }

            return null;
        }

        private void Sleep()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ArgumentHolder arguments = globalParameters.ArgumentHolder;
            Thread.Sleep(((arguments.TimeUnit * 1000) / arguments.IntervalOfArrivals) * (rnd.GetValue(1, 30) / 10));
        }
    }
}
