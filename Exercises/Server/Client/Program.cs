using System;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				TcpClient client = new TcpClient("127.0.0.1", 1302);
				string messageToSend = "This is my message";

				int byteCount = Encoding.ASCII.GetByteCount(messageToSend);
				byte[] sendData = new byte[byteCount];
				sendData = Encoding.ASCII.GetBytes(messageToSend);

				NetworkStream networkStream = client.GetStream();
				networkStream.Write(sendData, 0, sendData.Length);
				Console.WriteLine("Sending data to the server...");

				StreamReader streamReader = new StreamReader(networkStream);
				string responseFromServer = streamReader.ReadToEnd();
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
