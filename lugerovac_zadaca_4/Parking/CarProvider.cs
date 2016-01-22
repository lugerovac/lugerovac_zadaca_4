using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class CarProvider
    {
        private Automobile[] cars;
        private int numberOfCars;

        private static CarProvider instance;
        protected CarProvider()
        {
            GlobalParameters gp = GlobalParameters.GetInstance();
            numberOfCars = gp.ArgumentHolder.CarNumber;
            cars = new Automobile[numberOfCars];
        }

        public static CarProvider GetInstance()
        {
            if (instance == null)
                instance = new CarProvider();
            return instance;
        }

        public Automobile GiveFreeCar()
        {
            Randomizer rnd = Randomizer.GetInstance();
            int random = rnd.GetValue(0, numberOfCars);
            int i = random;
            int limit = random - 1;
            if (limit < 0)
                limit = numberOfCars - 1;

            for (; ; i++)
            {
                if (i == cars.Length)
                    i = 0;

                if(cars[i] == null)
                {
                    cars[i] = new Automobile(i);
                    return cars[i];
                }
                if (!cars[i].IsParked() && !cars[i].Conscificated)
                    return cars[i];
                if (i == limit)
                    break;
            }

            return null;
        }

        public List<Automobile> GiveCarList()
        {
            List<Automobile> returnValue = new List<Automobile>();
            foreach (Automobile car in cars)
                returnValue.Add(car);
            return returnValue;
        }
    }
}
