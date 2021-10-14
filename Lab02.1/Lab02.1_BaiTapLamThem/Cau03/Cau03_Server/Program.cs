using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Cau03_Server
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
                while (true)
                {
                    byte[] clientBuff = new byte[1024];
                    int byteReceive = clientSocket.Receive(clientBuff, 0, clientBuff.Length, SocketFlags.None);
                    string clientStr = Encoding.ASCII.GetString(clientBuff, 0, byteReceive);

                    Console.WriteLine("Ket qua gui len tu client: " + clientStr);

                    string[] items = Regex.Split(clientStr, @"[+|\-|x|/]");

                    int firstOperand = int.Parse(items[0]);
                    int secondOperand = int.Parse(items[1]);

                    double result = 0;

                    if (clientStr.Contains("+")) result = firstOperand + secondOperand;
                    else if (clientStr.Contains("-")) result = firstOperand - secondOperand;
                    else if (clientStr.Contains("x")) result = firstOperand * secondOperand;
                    else if (clientStr.Contains("/")) result = (double)firstOperand / secondOperand;

                    byte[] buff = Encoding.ASCII.GetBytes(result.ToString());
                    clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
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
