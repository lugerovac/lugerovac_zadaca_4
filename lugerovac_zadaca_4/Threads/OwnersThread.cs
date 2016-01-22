using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class OwnersThread
    {
        private Randomizer rnd;

        public OwnersThread()
        {
            rnd = Randomizer.GetInstance();
        }

        public void Start()
        {
            while(true)
            {
                Sleep();

                Parking parking = Parking.GetInstance();
                ParkingReservation reservation = parking.GetFirstReservation();
                if (reservation == null)
                    continue;

                int ownerChoice = rnd.GetValue(1, 5);

                switch (ownerChoice)
                {
                    case 1:
                        parking.MoveFirstToEnd();
                        break;
                    case 2:
                    case 3:
                        parking.Leave(reservation);
                        break;
                    case 4:
                        parking.ExtendReservation(reservation);
                        break;
                }

            }
        }

        private void Sleep()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ArgumentHolder arguments = globalParameters.ArgumentHolder;
            Thread.Sleep(((arguments.TimeUnit * 1000) / arguments.IntervalOfDepartures) * (rnd.GetValue(1, 30) / 10));
        }
    }
}
