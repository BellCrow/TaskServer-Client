#define WITHLOGGING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Messages;


namespace TaskServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int servPort = 55000;
            bool wasTwo = false;

            PostTaskMsg p = new PostTaskMsg(DateTime.Today, "TestComment", 3, PostTaskMsg.repeatIntervall.DAY);
            Workerpool bla = new Workerpool();
            TcpListener servSocket = new TcpListener(servPort);
            TcpClient tempClientCon;
            Console.WriteLine("Server Created\nListening for clients");
            servSocket.Start();
            tempClientCon = servSocket.AcceptTcpClient();
            Console.WriteLine("Got Client doing stuff now...");
            bla.addWorker(new Worker(tempClientCon, new EchoTask()));
            while (bla.getWorkerCount() > 0)
            {
                System.Threading.Thread.Sleep(3000);
                if (bla.getWorkerCount() == 2)
                    wasTwo = true;
                Console.WriteLine("Still working");
            }
        }
    }
}
