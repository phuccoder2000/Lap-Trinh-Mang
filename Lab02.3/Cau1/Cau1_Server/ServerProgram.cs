using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Cau1_Server
{
	public delegate void AddTextEventHandle(object sender, AddTextEventArgs args);

	public class ServerProgram
	{
		TcpListener server;

		public event AddTextEventHandle OnAddText;

		public void Start()
		{
			Thread mainThread = new Thread(new ThreadStart(StartConnection));
			mainThread.Start();
		}

		void StartConnection()
		{
			server = new TcpListener(IPAddress.Any, 5000);
			server.Start();

			while (true)
			{
				Thread clientThread = new Thread(new ThreadStart(ClientConnected));
				clientThread.Start();
			}
		}

		void ClientConnected()
		{
			TcpClient client = server.AcceptTcpClient();
			NetworkStream ns = client.GetStream();
			StreamReader reader = new StreamReader(ns);
			StreamWriter writer = new StreamWriter(ns);

			string str = "Hello Client";
			writer.WriteLine(str);
			writer.Flush();

			try
			{
				while (true)
				{

					str = reader.ReadLine();

					if (OnAddText != null)
					{
						string message = client.Client.RemoteEndPoint.ToString() + ": " + str;
						OnAddText(this, new AddTextEventArgs(message));
					}

					writer.WriteLine(str);
					writer.Flush();

				}
			}
			catch
			{
				if (OnAddText != null)
				{
					string message = client.Client.RemoteEndPoint.ToString() + ": " + "đã ngắt kết nối.";
					OnAddText(this, new AddTextEventArgs(message));
				}
				reader.Close();
				writer.Close();
				ns.Close();
				client.Close();
			}
		}
	}

	public class AddTextEventArgs : EventArgs
	{
		string text;

		public AddTextEventArgs(string text)
		{
			this.text = text;
		}

		public string Text
		{
			get { return text; }
			set { text = value; }
		}
	}
}
