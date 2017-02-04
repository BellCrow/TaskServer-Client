#define WITHLOGGING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Messages;
using System.Net;


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
            string pw = "notarealpassword";
            Connector serv = new Connector(IPAddress.Parse("127.0.0.1"),50000);
            

            DBConnector db = new DBConnector(conf);

            if(!db.connectToDataBase(ref pw))
            {
                Console.WriteLine("Could not connect to database:\nPress any button to exit Program:");
                Console.ReadKey();
                return;
            }
            MessageCommunicator mec = new MessageCommunicator(serv.listenForClient());
            MessageCommunicator mec2 = new MessageCommunicator(serv.listenForClient());

            Console.WriteLine("MAIN:Got first Client\nStarting Echo Worker");
            Worker w = new Worker(mec, new EchoTask(),db);
            w.startWork();

            Worker w2 = new Worker(mec2, new PrintContentTask(), db);
            w2.startWork();

            while(mec.isWorking())
            {
                Thread.Sleep(5000);
                Console.WriteLine("MAIN:Worker still working");
            }


            
        }
    }
}
