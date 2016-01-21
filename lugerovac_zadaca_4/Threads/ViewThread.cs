using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class ViewThread
    {
        public void Start()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            while (!globalParameters.ViewerPriority) ;

            PrintMainMenu();
            globalParameters.ControllerPriority = true;
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
            Console.Write("\nVaš unos: ");
        }
    }
}
