#define WITHLOGGING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TaskServer
{
    class Program
    {
        static void Main(string[] args)
        {
            PostTaskMsg p = new PostTaskMsg(DateTime.Today, "TestComment", 3, PostTaskMsg.repeatIntervall.DAY);
            
            Console.WriteLine(p.ToString());
            Console.ReadKey();
        }
    }
}
