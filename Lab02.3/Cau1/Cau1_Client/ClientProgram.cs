using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau1_Client
{
	public delegate void AddTextEventHandle(object sender, AddTextEventArgs args);

	public class ClientProgram
	{
		public event AddTextEventHandle OnAddText;

		StreamReader reader;
		StreamWriter writer;

		public void Connect()
		{
			TcpClient client = new TcpClient("127.0.0.1", 5000);
			NetworkStream ns = client.GetStream();
			reader = new StreamReader(ns);
			writer = new StreamWriter(ns);

			string str = reader.ReadLine();

			if (OnAddText != null)
				OnAddText(this, new AddTextEventArgs(str));
		}

		public void SendData(string text)
		{
			writer.WriteLine(text);
			writer.Flush();

			string str = reader.ReadLine();

			if (OnAddText != null)
				OnAddText(this, new AddTextEventArgs(str));
		}
	}

	public class AddTextEventArgs : EventArgs
	{
		string text;

		public AddTextEventArgs(string text)
		{
			this.text = text;
		}

		public string Text { get => text; set => text = value; }
	}
}
