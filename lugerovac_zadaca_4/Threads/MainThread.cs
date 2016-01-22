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
            StartViewThread();
            StartControllerThread();
            Thread.Sleep(100);
            StartCarGeneratingThread();
            Thread.Sleep(100);
            StartOwnerThread();
            Thread.Sleep(100);
            StartParkingControler();

            while (true)
            {
                if (!globalParameters.MainThreadRuns)
                    continue;
                Thread.Sleep(500);
            }
        }

        private void StartViewThread()
        {
            ViewThread viewer = new ViewThread();
            Thread viewThread = new Thread(new ThreadStart(viewer.Start));
            viewThread.Name = "View Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(viewThread);
            while (!viewThread.IsAlive) ;
        }

        private void StartControllerThread()
        {
            ControllerThread controller = new ControllerThread();
            Thread controllerThread = new Thread(new ThreadStart(controller.Start));
            controllerThread.Name = "Controler Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(controllerThread);
            while (!controllerThread.IsAlive) ;
        }

        private void StartCarGeneratingThread()
        {
            CarGeneratingThread generator = new CarGeneratingThread();
            Thread generatorThread = new Thread(new ThreadStart(generator.Start));
            generatorThread.Name = "Car Generator Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(generatorThread);
            while(!generatorThread.IsAlive);
        }

        private void StartOwnerThread()
        {
            OwnersThread owner = new OwnersThread();
            Thread ownerThread = new Thread(new ThreadStart(owner.Start));
            ownerThread.Name = "Owners Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(ownerThread);
            while (!ownerThread.IsAlive) ;
        }

        private void StartParkingControler()
        {
            ParkingControlerThread parkingControler = new ParkingControlerThread();
            Thread parkingControlerThread = new Thread(new ThreadStart(parkingControler.Start));
            parkingControlerThread.Name = "Owners Thread";
            ThreadHandler threadHandler = ThreadHandler.GetInstance();
            threadHandler.StartThread(parkingControlerThread);
            while (!parkingControlerThread.IsAlive) ;
        }
    }
}
