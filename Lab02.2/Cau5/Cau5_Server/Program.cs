using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau4_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string data;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5000);
            Socket newsock = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);
            Console.WriteLine("Dang cho Client ket noi toi...");
            Socket client = newsock.Accept();
            IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Da ket noi voi Client {0} tai port {1}",
            newclient.Address, newclient.Port);
            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string welcome = "Hello Client";
            sw.WriteLine(welcome);
            sw.Flush();
            while (true)
            {
                try
                {
                    data = sr.ReadLine();
                }
                catch (IOException)
                {
                    break;
                }
                Console.WriteLine(data);
                sw.WriteLine(data);
                sw.Flush();
            }
            Console.WriteLine("Da dong ket noi voi Client {0}", newclient.Address);
            sw.Close();
            sr.Close();
            ns.Close();
        }
    }
}
