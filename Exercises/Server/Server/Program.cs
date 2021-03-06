﻿using System;
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

            Database DB = new Database();
            //User user1 = new User("rares", "raresPassword");
            User user12 = new User("adi", "abcdefghijklmnopqrst");
            User user13 = new User("veltan", "alabalaportocoalalaslalal");
            User newUser = new User("UserNou", "parolaNoua");
            User newUser1 = new User("UserNou1", "parolaNoua1");
            //Console.WriteLine(user12.ID);
            //Console.WriteLine(newUser.ID);
            //Console.WriteLine(newUser1.ID);
            //DB.AddUser(user12);
            //DB.EditPassword(user12, "nouaParolaAluiAdi");
            //DB.DeleteUser(newUser1);
            User Adi = DB.GetUserById(3);
            
            
            //Server server = new Server();
            //server.AcceptLogin(); // in while
            
            Console.WriteLine(Adi.username + " " + Adi.password);

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
