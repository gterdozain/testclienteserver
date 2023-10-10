using System;
using System.Net;
using System.Net.Sockets;
using System.IO

namespace SegundaAct2
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Creamos servidor
            TcpListener listener = new TcpListener(64321);
          

            bool end = false;
            TcpClient client1 = null;
                client1 = listener.AcceptTcpClient();
                NetworkStream ns1 = client1.GetStream();

            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(stream);


            while (end == false)
            {
                //pide i responde

                string msg = Console.ReadLine();
                sw.WriteLine(msg);
                sw.Flush

                string msg1 = sr.ReadLine();
                Console.WriteLine(msg1);


            }

            listener.Stop();

        }
    }
}
