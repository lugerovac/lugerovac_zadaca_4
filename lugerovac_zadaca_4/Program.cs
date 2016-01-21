using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
