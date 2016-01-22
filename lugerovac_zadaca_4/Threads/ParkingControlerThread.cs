using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class ParkingControlerThread
    {
        public void Start()
        {
            while (true)
            {
                Sleep();
                Parking parking = Parking.GetInstance();
                ZoneIterator zIterator = new ZoneIterator(parking.GetParkingZones());
                if (zIterator.Count() == 0)
                    continue;

                for (Zone zone = (Zone)zIterator.First(); !zIterator.IsDone(); zone = (Zone)zIterator.Next())
                {
                    if (zone == null)
                        continue;
                    if (zone.Cars.Count == 0)
                        continue;

                    ViewerCache viewerCache = ViewerCache.GetInstance();
                    viewerCache.Add("Kontroler posjećuje zonu " + zone.ID.ToString());

                    CarIterator cIterator = new CarIterator(zone.Cars);
                    for(Automobile car = (Automobile)cIterator.First(); !cIterator.IsDone(); car = (Automobile)cIterator.Next())
                    {
                        if (car == null)
                            continue;
                        viewerCache.Add("Kontroler pregledava auto " + car.ID.ToString());
                        if (car.IllegalExtensions > 0)
                        {
                            GlobalParameters gp = GlobalParameters.GetInstance();
                            ArgumentHolder arguments = gp.ArgumentHolder;
                            int fine = ((zIterator.Count() + 1 - zone.ID) * arguments.UnitPrice * arguments.ParkingFine);
                            parking.Conscificate(zone, car, fine);
                        }
                        Sleep();
                    }
                    Sleep();
                }
            }
        }

        private void Sleep()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ArgumentHolder arguments = globalParameters.ArgumentHolder;
            Thread.Sleep((arguments.TimeUnit * 1000) / arguments.ControlInterval);
        }
    }

    abstract class ParkingControlerIterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
        public abstract int Count();
    }

    class CarIterator : ParkingControlerIterator
    {
        private List<Automobile> cars;
        private int index;

        public CarIterator(List<Automobile> cars)
        {
            this.cars = cars;
            index = 0;
        }

        public override object CurrentItem()
        {
            return cars[index];
        }

        public override object First()
        {
            return cars[0];
        }

        public override bool IsDone()
        {
            return index >= cars.Count - 1;
        }

        public override object Next()
        {
            if (index < cars.Count - 1)
                return cars[++index];
            else
                return null;
        }

        public override int Count()
        {
            return cars.Count;
        }
    }

    class ZoneIterator : ParkingControlerIterator
    {
        private Zone[] zones;
        private int index;

        public ZoneIterator(Zone[] zones)
        {
            this.zones = zones;
            index = 0;
        }

        public override object CurrentItem()
        {
            return zones[index];
        }

        public override object First()
        {
            return zones[0];
        }

        public override bool IsDone()
        {
            return index >= zones.Length - 1;
        }

        public override object Next()
        {
            if (index < zones.Length - 1)
                return zones[++index];
            else
                return null;
        }

        public override int Count()
        {
            return zones.Length;
        }
    }
}
