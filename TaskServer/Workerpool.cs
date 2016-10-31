using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskServer
{
    class Workerpool
    {
        List<Thread> _workerPool;
        public Workerpool()
        {
            _workerPool = new List<Thread>();
        }
        public int getWorkerCount()
        {
            return _workerPool.Count;
        }
        public void closeAllConnections()
        {

        }
    }
}
