using System;
using System.Net;
using System.Net.Sockets;

namespace SegundaAct2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos servidor
            TcpListener listener = new TcpListener(80);
            listener.Start(4); //Cola

            bool end = false;
            TcpClient client1 = null;
            TcpClient client2 = null;
            TcpClient client3 = null;
            TcpClient client4 = null;
            
            while (end == false)
            {
                if (client1 == null || client1.Connected == false)
                { 
                     client1 = listener.AcceptTcpClient();
                }
                if (listener.Pending() == true && (client2 == null || client2.Connected == false))
                {
                    client2 = listener.AcceptTcpClient();
                }
                if (listener.Pending() == true && (client3 == null || client3.Connected == false))
                {
                    client3 = listener.AcceptTcpClient();
                }
                if (listener.Pending() == true && (client4 == null || client4.Connected == false))
                {
                    client4 = listener.AcceptTcpClient();
                }

                //En casos urgentes
                client1.NoDelay = true;

                NetworkStream ns1 = client1.GetStream();
                NetworkStream ns2 = client2.GetStream();
                NetworkStream ns3 = client3.GetStream();
                NetworkStream ns4 = client4.GetStream();

                //Game loop

                if (end == true) {
                    client1.Close();
                    client2.Close();
                    client3.Close();
                    client4.Close();
                }
            }

            listener.Stop();

        }
    }
}
