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
            int counter = 0;
            foreach(Worker elem in _workerPool)
            {
                if (elem.isWorking())
                    counter++;
            }
            return counter;
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
