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
            ///Creamos servidor
            TcpListener listener = new TcpListener(64321);

            listener.Start();

            bool end = false;
            TcpClient client1 = listener.AcceptTcpClient();

            NetworkStream ns1 = client1.GetStream();

            BinaryWriter sw = new BinaryWriter(ns1);
            BinaryReader sr = new BinaryReader(ns1);

           

            while (end == false)
            {
                //pide y responde
                byte size2 = sr.ReadByte();


                if (size2 == 2)
                {
                    short msg = sr.ReadInt16();
                    Console.WriteLine(msg);


                }
                else if (size2 == 4)
                {

                    int msg = sr.ReadInt32();
                    Console.WriteLine(msg);
                }
                else if (size2 == 8)
                {

                    ulong msg = sr.ReadUInt64();
                    Console.WriteLine(msg);
                }

         //-------------------------------------------------
                string commando = Console.ReadLine(); 
                if (commando == "Patata")
                {
                    byte size = 2;
                    sw.Write(size);
                    short msgMessage = 21;
                    sw.Write(msgMessage);

                }
                else if (commando == "Lechuga")
                {
                    byte size = 4;
                    sw.Write(size);
                    int msgMessage = 31;
                    sw.Write(msgMessage);

                }
                else if (commando == "Tomate")
                {
                    byte size = 8;
                    sw.Write(size);
                    ulong msgMessage = 41;
                    sw.Write(msgMessage);

                }


            }

            listener.Stop();

        }
    }
}
