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

        protected GlobalParameters()
        {
            argumentHolder = new ArgumentHolder();
        }

        public static GlobalParameters GetInstance()
        {
            if (instance == null)
                instance = new GlobalParameters();

            return instance;
        }
    }
}
