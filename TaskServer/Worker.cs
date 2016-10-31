using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TaskServer
{

    class Worker
    {
        static int IDPool = 0;
        TcpClient _connection;
        int _connectionID;
        Queue<AbstractMessage> _messageQueue;
        public Worker(TcpClient connection)
        {
            _connection = connection;
            _messageQueue = new Queue<AbstractMessage>();
            _connectionID = ++IDPool;
        }
        public void startWork(Action<TcpClient> argFunction)
        {
            if (_connection.Connected == false)
                throw new Exception("Connection not established");
            argFunction(_connection);
        }
    }
}
