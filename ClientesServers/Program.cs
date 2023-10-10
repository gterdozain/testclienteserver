using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SegundaAct2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos servidor
            //TcpListener listener = new TcpListener(4534);
            //listener.Start(4); //Cola

            bool end = false;

            TcpClient client1 = new TcpClient();
            client1.Connect("127.0.0.1", 64321);

            NetworkStream ns1 = client1.GetStream();

            StreamWriter sw = new StreamWriter(ns1);
            StreamReader sr = new StreamReader(ns1);

            while (end == false)
            {
                string msg1 = sr.ReadLine();
                Console.WriteLine(msg1);

                string msg = Console.ReadLine();
                sw.WriteLine(msg);

                sw.Flush();
            }


        }
    }
}
