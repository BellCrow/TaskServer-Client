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
        List<Thread> _connectionPool;
        public Workerpool()
        {
            _connectionPool = new List<Thread>();
        }
        public int getWorkerCount()
        {
            return _connectionPool.Count;
        }
        public void closeAllConnections()
        {

        }
    }
}
