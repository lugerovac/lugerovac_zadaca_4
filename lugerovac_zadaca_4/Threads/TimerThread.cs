using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class TimerThread
    {
        public void Start()
        {
            while (true)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                GlobalParameters globalParameters = GlobalParameters.GetInstance();
                globalParameters.Timer++;
                sw.Stop();
                Thread.Sleep(1000 - sw.Elapsed.Milliseconds);
            }
        }
    }
}
