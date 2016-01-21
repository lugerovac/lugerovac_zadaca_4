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
        public bool MainThreadRuns { get; set; }

        protected GlobalParameters()
        {
            argumentHolder = new ArgumentHolder();
            MainThreadRuns = false;
        }

        public static GlobalParameters GetInstance()
        {
            if (instance == null)
                instance = new GlobalParameters();

            return instance;
        }
    }
}
