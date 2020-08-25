using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using ChatAppClasses;

namespace Server
{
    public class Server_class
    {
        public static Database serverDatabase;
        public static List<User> onlineUsers = new List<User>();
        int count = 1;
        static readonly object _lock = new object();
        static readonly Dictionary<int, TcpClient> list_clients = new Dictionary<int, TcpClient>();
        static readonly Dictionary<int, NetworkStream> list_networks = new Dictionary<int, NetworkStream>();

        public void connectToDatabase(Database database)
        {
            serverDatabase = database;
            Console.WriteLine("Connected to Database...");
        }
        public void run()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
            listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                Console.WriteLine("Waiting for connection...");

                TcpClient client = listener.AcceptTcpClient();
                NetworkStream client_stream = client.GetStream();
                list_networks.Add(count, client_stream);

                Console.WriteLine("Accepted Client");

                try
                {
                    list_clients.Add(count, client);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

                try
                {
                    Thread t = new Thread(handle_clients);
                    t.Start(count);
                    count++;


                }
                catch (Exception e)
                {

                    Console.WriteLine("Failed to start..." + e.Message);
                }
            }
        }
        public void handle_clients(object o)
        {
            int id = (int)o;
            Console.WriteLine(id);

            //TcpClient client;
            //lock (_lock) client = list_clients[id];

            NetworkStream ns;
            lock (_lock) ns = list_networks[id];

            Console.WriteLine("Arrived");
            IFormatter formatter = new BinaryFormatter();
            ChatAppClasses.Message messageFromClient = (ChatAppClasses.Message)formatter.Deserialize(ns);
            Console.WriteLine(messageFromClient.MessageText);
            
            while (true)
            {
                Console.WriteLine("msg");
                try
                {
                    
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("dupa msg");

                //if (messageFromClient.MessageText.Length == 0)
                //{
                //    break;
                //}

                //if(messageFromClient.Type == "Message")
                //broadcast(messageFromClient);

                //string response = handleIncomingMessage(messageFromClient);
                //stream.Write(Encoding.ASCII.GetBytes(response));
            }

            //lock (_lock) list_clients.Remove(id);
            //client.Client.Shutdown(SocketShutdown.Both);
            //client.Close();
        }

        public static void broadcast(ChatAppClasses.Message message)
        {
            //byte[] buffer = Encoding.ASCII.GetBytes(data + Environment.NewLine);
            IFormatter formatter = new BinaryFormatter();
            Console.WriteLine("arrived br");
            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    NetworkStream stream = c.GetStream();
                    //stream.Write(buffer, 0, buffer.Length);
                    formatter.Serialize(stream, message);
                }
            }
        }
        internal static void sendClientInvLoginMsg()
        {
            throw new NotImplementedException();
        }

        private static TcpClient acceptConnectionToClient(TcpListener listener)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client accepted...");
            return client;
        }
        public static string handleLogin(User user)
        {
            Login login = Login.Instance;

            string loginResponse = login.verifyLoginData(user);
            if (loginResponse == "Logged In!" || loginResponse == "Welcome, Admin!")
                onlineUsers.Add(user);

            return loginResponse;
        }

        public static void sendChatHistoryToClient()
        {

        }
        public string handleSignUp(User user)
        {
            SignUp signUp = SignUp.Instance;
            return SignUp.signUp(user);

            //de trimis catre client SignUpResponse


        }

        public static void sendDeleteConfirmationToClient()
        {

        }
        public static void getMessageInfoFromDB()
        {

        }
        public static void sendMessageInfoToClient()
        {

        }
        public static void getUserInfoFromDB()
        {

        }
        public static void sendUserInfoToClient()
        {

        }
        public string handleIncomingMessage(ChatAppClasses.Message messageFromClient)
        {
            Console.WriteLine("The message from the client is: " + messageFromClient.MessageText);
            //if (messageFromClient.Type == "Login" && serverDatabase.checkCredentials(messageFromClient.username, messageFromClient.password))
            //    return "Logged In!";

            switch (messageFromClient.Type)
            {
                case "Connection":
                    return "Connected";
                    break;
                case "Message":
                    return "Message handled!";
                    break;
                case "Login":
                    User user = new User();
                    user.username = messageFromClient.username;
                    user.password = messageFromClient.password;
                    //new User() { username = messageFromClient.username, password = messageFromClient.password }
                    return handleLogin(user);
                    break;
                case "SignUp":
                    return handleSignUp(new User() { username = messageFromClient.username, password = messageFromClient.password });
                    break;
            }
            Server_class.serverDatabase.saveMessageToDb(messageFromClient);
            return "No Case";

        }
        public void sendPrivateMessage()
        {

        }
        public void sendPublicMessage()
        {

        }
        public static void saveMessageToDB(ChatAppClasses.Message message)
        {
            serverDatabase.saveMessageToDb(message);
        }
        public void disconnectFromClient()
        {

        }
        public void disconnectFromDB()
        {

        }
    }
}
