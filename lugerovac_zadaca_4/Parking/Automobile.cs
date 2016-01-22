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
        private int illegalExtensions;
        public int IllegalExtensions
        {
            get
            {
                return illegalExtensions;
            }
            set
            {
                illegalExtensions = value;
            }
        }
        private bool conscificated;
        public bool Conscificated
        {
            get
            {
                return conscificated;
            }
        }
        private int fine;
        public int Fine
        {
            get
            {
                return fine;
            }
        }

        public Automobile(int id)
        {
            this.id = id;
            parkingBills = new List<int>();
            parked = false;
            extensions = 0;
            illegalExtensions = 0;
            conscificated = false;
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
            illegalExtensions = 0;
        }

        public void Conscificate()
        {
            conscificated = true;
        }

        public void Conscificate(int fine)
        {
            conscificated = true;
            this.fine = fine;
        }

        public bool IsParked()
        {
            return parked;
        }
    }
}
