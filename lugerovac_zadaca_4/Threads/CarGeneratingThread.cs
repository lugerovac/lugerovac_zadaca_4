using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class CarGeneratingThread
    {
        public void Start()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            ArgumentHolder arguments = globalParameters.ArgumentHolder;
            Randomizer rnd = Randomizer.GetInstance();
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            for (int i = 0; i < arguments.CarNumber; i++)
            {
                Thread.Sleep(((arguments.TimeUnit * 1000) / arguments.IntervalOfArrivals) * (rnd.GetValue(1, 20) / 10));
                AutomobileThread automobileThreadReference = new AutomobileThread();
                Thread automobileThread = new Thread(new ThreadStart(automobileThreadReference.Start));
                automobileThread.Name = "Car Generator Thread No. " + (i + 1).ToString();
                threadHandler.StartThread(automobileThread);
            }
            threadHandler.AbortThread(Thread.CurrentThread);
            while (true) ;
        }
    }
}
