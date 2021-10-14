using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab02._1_Cau2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Console.WriteLine("Dang doi ket noi tu client...");

            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndpoint = clientSocket.RemoteEndPoint;

            Console.WriteLine("Thong tin client ket noi: " + clientEndpoint.ToString());

            string hello = "Hello Client";

            byte[] buff = Encoding.ASCII.GetBytes(hello);

            clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);

            Console.ReadKey();

            serverSocket.Close();
            clientSocket.Close();
        }
    }
}
