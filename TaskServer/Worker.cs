using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Messages;

namespace TaskServer
{
    class Worker
    {
        static int IDPool = 0;
        MessageCommunicator _comLink;
        DBConnector _dbCon;
        int _connectionID;
        Thread _workerThread;
        bool _isWorking;
        IServerTask _task;
        public Worker(MessageCommunicator connection, IServerTask task, DBConnector dbCon)
        {
            _comLink = connection;
            _connectionID = ++IDPool;
            _task = task;
            _dbCon = dbCon;
            _isWorking = false;
        }
        public void startWork()
        {
            _workerThread = new Thread(()=>_task.startTask(_comLink,_dbCon));
            _workerThread.Name = "Echo Workerthread";
            _workerThread.Start();
            _isWorking = true;
        }
        public void requestStop()
        {
            _task.requestStop();
        }
        public void stopWorkingForce()
        {
            _workerThread.Abort();
            _isWorking = false;
            
        }
        public bool isWorking()
        {
            if (_workerThread == null || !_workerThread.IsAlive)
                return false;
            return true;
        }
    }
}
