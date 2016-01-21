using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class GlobalParameters
    {
        public static GlobalParameters instance;
        private ArgumentHolder argumentHolder;
        public ArgumentHolder ArgumentHolder
        {
            get
            {
                return argumentHolder;
            }

            set
            {
                argumentHolder = value;
            }
        }
        private bool mainThreadRuns = false;
        public bool MainThreadRuns
        {
            get
            {
                return mainThreadRuns;
            }
            set
            {
                mainThreadRuns = value;
                if(!mainThreadRuns)
                {
                    ThreadHandler threadHandler = ThreadHandler.GetInstance();
                    threadHandler.AbortAllThreads();
                }
            }
        }
        public int AutomobileThreadCounter;

        private bool viewerPriority;
        public bool ViewerPriority
        {
            get
            {
                return viewerPriority;
            }
            set
            {
                viewerPriority = value;
                controllerPriority = !viewerPriority;
            }
        }

        private bool controllerPriority;
        public bool ControllerPriority
        {
            get
            {
                return controllerPriority;
            }
            set
            {
                controllerPriority = value;
                viewerPriority = !controllerPriority;
            }
        }
        
        protected GlobalParameters()
        {
            argumentHolder = new ArgumentHolder();
            AutomobileThreadCounter = 0;
            ViewerPriority = true;
        }

        public static GlobalParameters GetInstance()
        {
            if (instance == null)
                instance = new GlobalParameters();

            return instance;
        }
    }
}
