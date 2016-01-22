using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class Parking
    {
        private static Parking instance;
        private Monitor monitor;
        private Zone[] zones;
        private List<ParkingReservation> reservations;
        private bool open;

        protected Parking()
        {
            monitor = new Monitor();
            reservations = new List<ParkingReservation>();
            open = true;
        }

        public static Parking GetInstance()
        {
            if (instance == null)
                instance = new Parking();
            return instance;
        }

        public void InitializeZones(int numberOfZones, int zoneCapacity, int parkingTime, int timeUnit)
        {
            zones = new Zone[numberOfZones];
            for(int i = 1; i <= numberOfZones; i++)
            {
                zones[i-1] = new Zone(i, zoneCapacity, parkingTime, timeUnit);
            }
        }

        public void Close()
        {
            monitor.Check();
            open = false;
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ViewerCache viewerCache = ViewerCache.GetInstance();
            viewerCache.AddReport(globalParameters.Timer.ToString() + ": Parkiralište je zatvoreno");
            monitor.Release();
        }

        public void Open()
        {
            monitor.Check();
            open = true;
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ViewerCache viewerCache = ViewerCache.GetInstance();
            viewerCache.AddReport(globalParameters.Timer.ToString() + ": Parkiralište je otvoreno");
            monitor.Release();
        }

        public void CalculateBillProfits()
        {
            monitor.Check();
            foreach (Zone zone in zones)
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                ViewerCache viewerCache = ViewerCache.GetInstance();
                viewerCache.AddReport(globalParameters.Timer.ToString() + ": Profit u zoni " + zone.ID.ToString() + " = " + zone.Profit.ToString() + " HRK");
            }
            monitor.Release();
        }

        public void CalculateFineProfits()
        {
            monitor.Check();
            foreach (Zone zone in zones)
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                ViewerCache viewerCache = ViewerCache.GetInstance();
                viewerCache.AddReport(globalParameters.Timer.ToString() + ": Profit od kazni u zoni " + zone.ID.ToString() + " = " + zone.Fines.ToString() + " HRK");
            }
            monitor.Release();
        }

        public void ShowLostClientNumber()
        {
            monitor.Check();
            foreach (Zone zone in zones)
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                ViewerCache viewerCache = ViewerCache.GetInstance();
                viewerCache.AddReport(globalParameters.Timer.ToString() + ": Broj izgubljenih klijenata u zoni " + zone.ID.ToString() + " = " + zone.LostClients.ToString());
            }
            monitor.Release();
        }

        public void ShowConscificatedNumber()
        {
            monitor.Check();
            foreach (Zone zone in zones)
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                ViewerCache viewerCache = ViewerCache.GetInstance();
                viewerCache.AddReport(globalParameters.Timer.ToString() + ": Broj deponiranih automobila u zoni " + zone.ID.ToString() + " = " + zone.ConscificatedCars.ToString());
            }
            monitor.Release();
        }

        public void ShowBestClients()
        {
            monitor.Check();

            CarProvider carProvider = CarProvider.GetInstance();
            List<Automobile> cars = carProvider.GiveCarList();
            List<Automobile> bestClients = new List<Automobile>();

            for(int i = 0; i < 5; i++)
            {
                if (cars.Count == 0)
                    break;

                int bestResult = 0;
                List<Automobile> temp = new List<Automobile>();

                foreach(Automobile car in cars)
                {
                    if (car == null)
                        continue;

                    if(car.ParkingBills.Count > bestResult)
                    {
                        bestResult = car.ParkingBills.Count;
                        temp.Clear();
                        temp.Add(car);
                    } else if(car.ParkingBills.Count == bestResult)
                    {
                        temp.Add(car);
                    }
                }

                foreach(Automobile car in temp)
                {
                    bestClients.Add(car);
                    cars.Remove(car);                                    
                }

                if (bestClients.Count >= 5)
                    break;
            }

            ViewerCache viewerCache = ViewerCache.GetInstance();
            int position = 1;
            foreach(Automobile car in bestClients)
            {
                viewerCache.AddReport(position.ToString() + ". " + "Automobil " + car.ID + ": " + car.ParkingBills.Count.ToString());
                position++;
            }

            monitor.Release();
        }

        public void ShowZoneAvailability()
        {
            monitor.Check();
            foreach (Zone zone in zones)
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                ViewerCache viewerCache = ViewerCache.GetInstance();
                int capacity = zone.Capacity;
                int reservedCapacity = zone.Cars.Count();
                double ratio = (Convert.ToDouble(reservedCapacity) / Convert.ToDouble(capacity)) * 100.0;
                int intRatio = Convert.ToInt32(ratio);

                viewerCache.AddReport(globalParameters.Timer.ToString() + ": Zauzetost zone " + zone.ID.ToString() + " = " + intRatio.ToString() + "%");
            }
            monitor.Release();
        }

        public Zone[] GetParkingZones()
        {
            return zones;
        }

        public bool ReservePlaceInZone(Automobile car, Zone zone)
        {
            monitor.Check();

            bool returnValue;
            if (!open)
            {
                returnValue = false;
            }
            else if (zone.IsFull())
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                ViewerCache viewerCache = ViewerCache.GetInstance();
                zone.LostClients++;
                viewerCache.Add(globalParameters.Timer.ToString() + ": Automobilu " + car.ID + " odbijeno parkiranje u zoni " + zone.ID.ToString() + " jer nije bilo prostora");
                returnValue = false;
            }
            else
            {
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                int currentTime = globalParameters.Timer;
                ParkingReservation newReservation = new ParkingReservation(car, zone, currentTime);
                reservations.Add(newReservation);
                zone.Add(car);
                int parkingBill = (zones.Length + 1 - zone.ID) * globalParameters.ArgumentHolder.UnitPrice;
                car.AddParkingBill(parkingBill);
                zone.Profit = parkingBill;
                ViewerCache viewerCache = ViewerCache.GetInstance();
                viewerCache.Add(currentTime.ToString() + ": Naplaćeno parkiranje u zoni " + zone.ID.ToString() + " automobilu " + car.ID.ToString() + " u iznosu od " + parkingBill.ToString() + " HRK");
                returnValue = true;
            }

            monitor.Release();
            return returnValue;
        }

        public void Leave(ParkingReservation reservation)
        {
            monitor.Check();
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            int currentTime = globalParameters.Timer;
            reservation.Car.Leave();
            reservation.Zone.Remove(reservation.Car);
            reservations.Remove(reservation);
            ViewerCache viewerCache = ViewerCache.GetInstance();
            viewerCache.Add(currentTime.ToString() + ": Automobil " + reservation.Car.ID.ToString() + " napušta zonu " + reservation.Zone.ID.ToString());
            monitor.Release();
        }

        public void Conscificate(Zone zone, Automobile car, int fine)
        {
            monitor.Check();
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            int currentTime = globalParameters.Timer;
            ParkingReservation reservation = FindReservation(zone, car);
            car.Conscificate(fine);
            zone.Fines = fine;
            zone.Remove(car);
            zone.ConscificatedCars++;
            reservations.Remove(reservation);
            ViewerCache viewerCache = ViewerCache.GetInstance();
            viewerCache.Add(currentTime.ToString() + ": Automobil " + car.ID.ToString() + " u zoni " + zone.ID.ToString() 
                + " je conscificiran a vlasniku je data kazna u vrijednosti od " + fine.ToString() + " HRK");
            monitor.Release();
        }

        private ParkingReservation FindReservation(Zone zone, Automobile car)
        {
            foreach(ParkingReservation reservation in reservations)
            {
                if (reservation.Zone == zone && reservation.Car == car)
                    return reservation;
            }
            return null;
        }

        public void ExtendReservation(ParkingReservation reservation)
        {
            monitor.Check();
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            int currentTime = globalParameters.Timer;
            ViewerCache viewerCache = ViewerCache.GetInstance();
            if (reservation.Car.Extensions < reservation.Zone.MaxExtensions)
            {
                int parkingBill = (zones.Length + 1 - reservation.Zone.ID) * globalParameters.ArgumentHolder.UnitPrice;
                reservation.Car.AddParkingBill(parkingBill);
                reservation.Zone.Profit = parkingBill;
                reservation.Car.Extensions++;
                viewerCache.Add(currentTime.ToString() + ": Vlasnik automobila " + reservation.Car.ID.ToString() + " je produljio parkiranje u zoni "
                    + reservation.Zone.ID.ToString() + " i platio " + parkingBill.ToString() + " HRK");
                monitor.Release();
            } else
            {
                viewerCache.Add(currentTime.ToString() + ": Vlasniku automobila " + reservation.Car.ID.ToString() + ", parkiranog u zoni " 
                    + reservation.Zone.ID.ToString() + " odbijeno je produljenje");
                monitor.Release();
                Leave(reservation);
            }
            
        }

        public ParkingReservation GetFirstReservation()
        {
            monitor.Check();
            ParkingReservation returnValue;
            if (reservations.Count == 0)
                returnValue = null;
            else
                returnValue = reservations.First();
            monitor.Release();
            return returnValue;
        }

        public void RemoveFirstReservation()
        {
            monitor.Check();
            reservations.Remove(reservations.First());
            monitor.Release();
        }

        public void RemoveReservation(ParkingReservation reservation)
        {
            monitor.Check();
            reservations.Remove(reservation);
            monitor.Release();
        }

        public void MoveFirstToEnd()
        {
            monitor.Check();
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            int currentTime = globalParameters.Timer;
            ParkingReservation reservation = reservations.First();
            reservations.Remove(reservation);
            reservations.Add(reservation);
            reservation.Car.IllegalExtensions++;
            ViewerCache viewerCache = ViewerCache.GetInstance();
            viewerCache.Add(currentTime.ToString() + ": Vlasnik automobila " + reservation.Car.ID.ToString() + " ostavlja automobil u zoni " + reservation.Zone.ID.ToString() + " bez legalnog produljenja");
            monitor.Release();
        }
    }
}
