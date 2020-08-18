using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Server
    {
        private Database myDatabase;

        public void connectToDatabase(Database database)
        {
            this.myDatabase = database;
        }
        public void run()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for connection...");
                TcpClient client = acceptConnectionToClient(listener);

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

        private static TcpClient acceptConnectionToClient(TcpListener listener)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client accepted...");
            return client;
        }
    }
}
