using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lugerovac_zadaca_4
{
    public class ViewerCache
    {
        private string[] cache;
        private int indexer;
        public bool Updated;
        private bool busy;

        private static ViewerCache instance;
        protected ViewerCache()
        {
            cache = new string[10];
            Updated = false;
            indexer = 0;
            busy = false;
        }

        public static ViewerCache GetInstance()
        {
            if (instance == null)
                instance = new ViewerCache();
            return instance;
        }

        public void Add(string text)
        {
            while(Updated || busy)
            {
                Thread.Sleep(10);
            }

            busy = true;

            cache[indexer++] = text;
            if (indexer == cache.Length)
                indexer = 0;
            Updated = true;
            busy = false;
        }

        public void PrintCache()
        {
            busy = true;
            int i = indexer;
            int limit = i - 1;
            if (limit < 0)
                limit = cache.Length - 1;

            for (; ; i++)
            {
                if (i == cache.Length)
                    i = 0;
                Console.WriteLine(cache[i]);
                if (i == limit)
                    break;
            }
            busy = false;
        }
    }
}
