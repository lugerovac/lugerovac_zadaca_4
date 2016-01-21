using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class MainThread
    {
        public void Start()
        {
            GlobalParameters globalParameters = GlobalParameters.GetInstance();
            globalParameters.MainThreadRuns = true;
            StartviewThread();
            StartControllerThread();
            StartCarGeneratingThread();

            while (true)
            {
                if (!globalParameters.MainThreadRuns)
                    continue;
            }
        }

        private void StartviewThread()
        {
            ViewThread viewer = new ViewThread();
            Thread viewThread = new Thread(new ThreadStart(viewer.Start));
            viewThread.Name = "View Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(viewThread);
        }

        private void StartControllerThread()
        {
            ControllerThread controller = new ControllerThread();
            Thread controllerThread = new Thread(new ThreadStart(controller.Start));
            controllerThread.Name = "Controler Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(controllerThread);
        }

        private void StartCarGeneratingThread()
        {
            CarGeneratingThread generator = new CarGeneratingThread();
            Thread generatorThread = new Thread(new ThreadStart(generator.Start));
            generatorThread.Name = "Car Generator Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(generatorThread);
        }
    }
}
