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
        private int timer;
        public int Timer
        {
            get
            {
                return timer;
            }
            set
            {
                timer = value;
            }
        }
        
        protected GlobalParameters()
        {
            argumentHolder = new ArgumentHolder();
            AutomobileThreadCounter = 0;
            timer = 0;
        }

        public static GlobalParameters GetInstance()
        {
            if (instance == null)
                instance = new GlobalParameters();

            return instance;
        }
    }
}
