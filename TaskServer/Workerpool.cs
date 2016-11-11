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
        List<Worker> _workerPool;
        public Workerpool()
        {
            _workerPool = new List<Worker>();
        }
        public int getWorkerCount()
        {
            return _workerPool.Count;
        }
        public void closeAllConnections()
        {
            foreach(Worker elem in _workerPool)
            {
                elem.stopWorkingForce();
            }
        }
        public bool addWorker(Worker workerArg)
        {
            try 
            {
                _workerPool.Add(workerArg);
                workerArg.startWork();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
