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
        int _connectionID;
        Thread _workerThread;
        bool _isWorking;
        IServerTask _task;
        public Worker(TcpClient connection,IServerTask task)
        {
            _comLink = new MessageCommunicator(connection);
            _connectionID = ++IDPool;
            _task = task;
            _isWorking = false;
        }
        public void startWork()
        {
            _workerThread = new Thread(()=>_task.startTask(_comLink));
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
