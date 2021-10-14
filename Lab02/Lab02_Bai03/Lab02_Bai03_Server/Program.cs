using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab02_Bai03_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Dang cho ket noi phia client....");
            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Socket clientSocket = serverSocket.Accept();

            EndPoint clientEndpoint = clientSocket.RemoteEndPoint;
            Console.WriteLine("Thong tin client ket noi: " + clientEndpoint.ToString());

            byte[] buff;
            string hello = "Hello client";
            buff = Encoding.ASCII.GetBytes(hello);

            clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);

            clientSocket.Close();
            serverSocket.Close();
        }
    }
}
