using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MILSTD1553ClassLibrary;

namespace deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServer server = new TCPServer();
            TCPClient client = new TCPClient();

            Thread t1 = new Thread(tBC);
            Thread t2 = new Thread(tRT);

            t1.Start(server);
            t2.Start(client);
            while (true) ;
        }

        public static void tBC(object o)
        {
            Console.WriteLine("BC thread is started");
            TCPServer server = (TCPServer)o;
            int[] data1 = { 1 };
            int[] data2 = new int[1];
            while (true)
            {
                server.send(data1);
                data2 = server.receive();
                if (data2[0] == data1[0])
                {
                    Console.WriteLine("BC sent and RT echo");
                }
                Thread.Sleep(1000);
            }
            

            
        }
        public static void tRT(object o)
        {
            Console.WriteLine("RT thread is started");
            TCPClient client = (TCPClient)o;
            while (true)
            {
                int[] dataReceived = client.receive();
                if (dataReceived[0] == 1)
                {
                    client.send(dataReceived);
                }
            }
            
            
        }
    }
}
