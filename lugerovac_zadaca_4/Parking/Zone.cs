using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class Zone
    {
        private List<Automobile> cars;
        public List<Automobile> Cars
        {
            get
            {
                return cars;
            }
        }
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
        }
        private int parkingTime;
        private int capacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }
        private int maxExtensions;
        public int MaxExtensions
        {
            get
            {
                return maxExtensions;
            }
        }
        private int profit;
        public int Profit
        {
            get
            {
                return profit;
            }
            set
            {
                profit += value;
            }
        }
        private int fines;
        public int Fines
        {
            get
            {
                return fines;
            }
            set
            {
                fines += value;
            }
        }
        private int lostClients;
        public int LostClients
        {
            get
            {
                return lostClients;
            }
            set
            {
                lostClients = value;
            }
        }
        private int conscificatedCars;
        public int ConscificatedCars
        {
            get
            {
                return conscificatedCars;
            }
            set
            {
                conscificatedCars = value;
            }
        }

        public Zone(int id, int capacity, int parkingTime, int timeUnit)
        {
            cars = new List<Automobile>();
            this.id = id;
            this.capacity = id * capacity;
            this.parkingTime = id * parkingTime * timeUnit;
            maxExtensions = id - 1;
        }

        public bool IsFull()
        {
            if (cars.Count == capacity)
                return true;
            else
                return false;
        }

        public void Add(Automobile car)
        {
            cars.Add(car);
        }

        public void Remove(Automobile car)
        {
            cars.Remove(car);
        }
    }
}
