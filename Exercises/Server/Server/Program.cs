using System;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any,1302);
            listener.Start();

            while(true)
            {
                Console.WriteLine("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client accepted...");
                
                NetworkStream networkStream = client.GetStream();
                StreamReader streamReader = new StreamReader(client.GetStream());
                StreamWriter streamWriter = new StreamWriter(client.GetStream());

                try
                {
                    byte[] buffer = new byte[1024];
                    networkStream.Read(buffer);

                    string messageFromClient = Encoding.UTF8.GetString(buffer);
                    //streamWriter.Write("Server received your request");
                    networkStream.Write(Encoding.ASCII.GetBytes("Server received your request"));
                    Console.WriteLine("The message from the client is: " + messageFromClient);
                    Console.WriteLine();

                    streamWriter.Flush();
                    streamWriter.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine("Failed to start...");
                }
            }
        }
    }
}
