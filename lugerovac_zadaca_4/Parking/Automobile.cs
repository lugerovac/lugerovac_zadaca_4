using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class Automobile
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
        }
        private List<int> parkingBills;
        private bool parked;
        private int extensions;
        public int Extensions
        {
            get
            {
                return extensions;
            }
            set
            {
                extensions = value;
            }
        }

        public Automobile(int id)
        {
            this.id = id;
            parkingBills = new List<int>();
            parked = false;
            extensions = 0;
        }

        public void AddParkingBill(int amount)
        {
            parkingBills.Add(amount);
        }

        public void Park()
        {
            parked = true;
        }

        public void Leave()
        {
            parked = false;
            extensions = 0;
        }

        public bool IsParked()
        {
            return parked;
        }
    }
}
