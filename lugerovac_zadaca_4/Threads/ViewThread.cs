using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class ViewThread
    {
        public void Start()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            while (true)
            {
                Console.Clear();
                PrintCache();
                PrintMainMenu();
                globalParameters.ControllerPriority = true;

                while (!globalParameters.ViewerPriority)
                {
                    ViewerCache cache = ViewerCache.GetInstance();
                    if (cache.Updated)
                        globalParameters.ViewerPriority = true;
                    Thread.Sleep(30);
                }
            }
        }

        private void PrintCache()
        {
            ViewerCache cache = ViewerCache.GetInstance();
            cache.PrintCache();
            cache.Updated = false;
        }

        private void PrintMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Zatvaranje parkirališta za nove ulaze automobila");
            Console.WriteLine("2 - Otvaranje parkirališta za nove ulaze automobila");
            Console.WriteLine("3 - Ispis zarada od parkiranja po zonama");
            Console.WriteLine("4 - Ispis zarada od kazni po zonama");
            Console.WriteLine("5 - Ispis broja automobila koji nisu mogli parkirati po zonama");
            Console.WriteLine("6 - Ispis broja automobila koji je pauk odveo na deponij po zonama");
            Console.WriteLine("7 - Ispis 5 automobila s najviše parkiranja");
            Console.WriteLine("8 - Stanje parkirnih mjesta po zonama (% zauzetih)");
            Console.WriteLine("Q - Prekid rada programa.");
            Console.Write("\nKliknite na tipkovnici za željenu opciju");
        }
    }
}
