﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class Zone
    {
        List<Automobile> cars;
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

        public Zone(int id, int capacity, int parkingTime, int timeUnit)
        {
            cars = new List<Automobile>();
            this.id = id;
            this.capacity = id * capacity;
            this.parkingTime = id * parkingTime * timeUnit;
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
