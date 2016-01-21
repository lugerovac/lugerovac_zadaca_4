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
        private Automobile automobile;
        private int id;

        public AutomobileThread()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            int id = globalParameters.AutomobileThreadCounter++;
            automobile = new Automobile(id);
            this.id = id;
        }

        public void Start()
        {
            Thread.Sleep(500);
        }
    }
}
