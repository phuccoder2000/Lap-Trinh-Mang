using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau1_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndpoint);
            serverSocket.Listen(10);

            Console.WriteLine("Dang cho client ket noi...");

            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndpoint = clientSocket.RemoteEndPoint;

            Console.WriteLine("Thong tin client ket noi: " + clientEndpoint.ToString());

            try
            {
                byte[] buff = new byte[1024];

                for (int i = 0; i < 8; i++)
                {
                    int byteReceive = clientSocket.Receive(buff);
                    string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                    Console.WriteLine(str);
                }
            }
            catch
            {
                Console.WriteLine("Client da ngat ket noi! Thoat chuong trinh!");
            }

            Console.ReadKey();

            serverSocket.Close();
        }
    }
}
