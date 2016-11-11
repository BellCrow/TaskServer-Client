#define WITHLOGGING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;



namespace TaskServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int servPort = 55000;

            PostTaskMsg p = new PostTaskMsg(DateTime.Today, "TestComment", 3, PostTaskMsg.repeatIntervall.DAY);
            Workerpool bla = new Workerpool();
            TcpListener servSocket = new TcpListener(servPort);
            TcpClient tempClientCon;
            servSocket.Start();
            tempClientCon = servSocket.AcceptTcpClient();

            Console.WriteLine(p.ToString());
            Console.ReadKey();
        }
    }
}
