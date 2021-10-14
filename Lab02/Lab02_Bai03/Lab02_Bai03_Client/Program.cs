using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab02_Bai03_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Dang ket noi voi server....");

            serverSocket.Connect(serverEndpoint);    

            if (serverSocket.Connected)
            {
                Console.WriteLine("Ket noi thanh cong voi server...");
                byte[] buff = new byte[32];
                int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                string message = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine("Thong diep tu server: " + message);
            }

            Console.ReadKey();
            serverSocket.Close();
        }
    }
}
