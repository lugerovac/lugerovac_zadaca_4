using System;

namespace lugerovac_zadaca_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (!MainFacade.InitializeArguments(args))
            {
                Console.WriteLine("Došlo je do pogreške kod čitanja argumenata! Program se prekida!");
                return;
            }

            if(!MainFacade.StartApp())
            {
                Console.WriteLine("Došlo je do pogreške tjekom rada aplikacije!");
                return;
            }
        }
    }
}
