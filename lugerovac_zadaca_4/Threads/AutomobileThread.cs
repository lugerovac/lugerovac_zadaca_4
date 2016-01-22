using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class AutomobileThread
    {
        private Automobile car;
        private int id;

        public AutomobileThread()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            int id = globalParameters.AutomobileThreadCounter++;
            car = new Automobile(id);
            this.id = id;
        }

        public void Start()
        {
            Parking parking = Parking.GetInstance();
            Zone[] AvailableZones = parking.GetParkingZones();

            Randomizer randomizer = Randomizer.GetInstance();
            int rnd2 = randomizer.GetValue(0, AvailableZones.Length - 1);
            //int chosenZone = (AvailableZones.Length * rnd2);
            int chosenZone = rnd2;

            bool reserved = parking.ReservePlaceInZone(car, AvailableZones[chosenZone]);
            ViewerCache viewerCache = ViewerCache.GetInstance();
            if (reserved)
            {
                viewerCache.Add("Automobil " + id.ToString() + " se parkirao u zoni " + chosenZone.ToString());
            }else
            {
                viewerCache.Add("Automobil " + id.ToString() + " se nije uspjeo parkirati u zoni " + chosenZone.ToString());
            }

            GoToSleep();
        }

        private void GoToSleep()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ArgumentHolder arguments = globalParameters.ArgumentHolder;
            Randomizer rnd = Randomizer.GetInstance();
            Thread.Sleep((arguments.TimeUnit / arguments.IntervalOfArrivals) * rnd.GetValue(10, 300));
        }
    }
}
