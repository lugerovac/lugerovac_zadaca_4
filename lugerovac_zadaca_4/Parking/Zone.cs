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
        private int maxExtensions;
        public int MaxExtensions
        {
            get
            {
                return maxExtensions;
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
