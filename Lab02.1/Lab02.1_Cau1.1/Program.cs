using System;
using System.Net;
using System.Net.Sockets;

namespace Lab02._1_Cau1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           
            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Console.WriteLine("Dang doi client ket noi...");

            Socket clientSocket = serverSocket.Accept();

            EndPoint clientEndpoint = clientSocket.RemoteEndPoint;
            Console.WriteLine("Thong tin client ket noi: " + clientEndpoint.ToString());

            Console.ReadKey();

            serverSocket.Close();
            clientSocket.Close();
        }
    }
}
