using System;
using System.Net;

namespace Lab01_Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            string domain = "";
            Console.WriteLine("Nhap ten mien: ");
            domain = Console.ReadLine();

            GetHostInfo(domain);
        }

        static void GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);

                Console.WriteLine("Ten mien: " + hostInfo.HostName);
                Console.WriteLine("Danh sach dia chi IP: ");

                foreach (IPAddress iPAddress in hostInfo.AddressList)
                {
                    Console.WriteLine(iPAddress.ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Khong phan giai duoc ten mien: " + host + "\n");
            }
        }
    }
}
