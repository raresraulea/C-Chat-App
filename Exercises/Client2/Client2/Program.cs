using System;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0]; //exercise purposes
				TcpClient client = new TcpClient(Dns.GetHostName(), 1302);
				string messageToSend = "This is my message";

				int byteCount = Encoding.ASCII.GetByteCount(messageToSend);
				byte[] sendData = new byte[byteCount + 1];
				sendData = Encoding.ASCII.GetBytes(messageToSend);

				NetworkStream networkStream = client.GetStream();
				networkStream.Write(sendData, 0, sendData.Length);
				Console.WriteLine("Sending data to the server...");

				StreamReader streamReader = new StreamReader(networkStream);
				string responseFromServer = streamReader.ReadLine();
				Console.WriteLine(responseFromServer);

				networkStream.Close();
				client.Close();
			}
			catch (Exception e)
			{

				Console.WriteLine("failed to connect...");
			}
		}
	}
}
