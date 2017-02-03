#define WITHLOGGING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Messages;


namespace TaskServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Config conf = new Config();
            conf.DbAddress = "127.0.0.1";
            conf.DbDatabaseName = "taskdatabase";
            conf.DbUserName = "taskuser";
            string pw = ;
            MessageCommunicator mec = new MessageCommunicator(50000);

            DBConnector db = new DBConnector(conf);

            db.connectToDataBase(ref pw);
            mec.listenForClient();
            Console.WriteLine("MAIN:Got first Client\nStarting Echo Worker");
            Worker w = new Worker(mec, new EchoTask(),db);
            w.startWork();
            while(mec.isWorking())
            {
                Thread.Sleep(5000);
                Console.WriteLine("MAIN:Worker still working");
            }
        }
    }
}
