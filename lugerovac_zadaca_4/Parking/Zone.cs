using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class Zone
    {
        List<Automobile> automobiles;
        private int id;
        private int capacity;
        private int parkingTime;

        public Zone(int id, int capacity, int parkingTime, int timeUnit)
        {
            automobiles = new List<Automobile>();
            this.id = id;
            this.capacity = id * capacity;
            this.parkingTime = id * parkingTime * timeUnit;
        }
    }
}
