using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        List<string> chat = new List<string>();
        static int clientID = 1;

        public void connectToDatabase(Database database)
        {
            serverDatabase = database;
            Console.WriteLine("Connected to Database...");
        }
        public void run()
        {
            clientList.Clear();
            onlineUsers.Clear();

            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
            listener.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                Console.WriteLine("Waiting for connection...");

                TcpClient client = acceptConnectionToClient(listener);
                NetworkStream networkStream = client.GetStream();

                try
                {
                    byte[] buffer = new byte[1024];

                    if (!clientList.ContainsValue(client))
                    {
                        var thread = new Thread(() => handleIncomingMessage(client));
                        thread.Start();
                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine("Failed to start..." + e.Message);
                }
            }
        }
        public void handleIncomingMessage(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();

            ChatAppClasses.Message messageFromClient;
            messageFromClient = (ChatAppClasses.Message)formatter.Deserialize(stream);

            bool flag_first = true;

            if (!clientList.ContainsValue(client))
            {
                clientList.Add(messageFromClient.username, client);
                clientID++;
            }
            
                var clientInDictionary = clientList.First(dictionaryItem => dictionaryItem.Value == client);
            Console.WriteLine("Handling " + clientInDictionary.Key);

            while (true)
            {
                try
                {

                    stream = client.GetStream();
                    StreamWriter streamWriter = new StreamWriter(stream);
                    Console.WriteLine("inainte");

                    if (!flag_first)
                    {
                        messageFromClient = (ChatAppClasses.Message)formatter.Deserialize(stream);
                        Console.WriteLine("Update MEssage" + messageFromClient.Type);

                    }
                    //Console.WriteLine("The message from the client is: " + messageFromClient.MessageText);


                    string response;
                    switch (messageFromClient.Type)
                    {
                        case "Connection":
                            response = "Connected";
                            flag_first = false;
                            break;
                        case "Message":
                            response = "Message handled!";
                            break;
                        case "Login":
                            User user = new User();
                            user.username = messageFromClient.username;
                            user.password = messageFromClient.password;
                            response = handleLogin(user);
                            if (response == "Logged In!" || response == "Welcome, Admin!")
                                sendUsersList();
                            flag_first = false;
                            break;
                        case "Logout":
                            var clientToBeRemoved = clientList.First(dictionaryItem => dictionaryItem.Value == client);
                            clientList.Remove(clientToBeRemoved.Key);
                            response = "Logged Out!";
                            sendUsersList();
                            break;
                        case "SignUp":
                            response = handleSignUp(new User() { username = messageFromClient.username, password = messageFromClient.password });
                            break;

                        default:
                            response = "Error";
                            break;
                    }

                    //foreach (var clientActual in clientList)
                    //    Console.WriteLine(clientActual.Key);

                    Console.WriteLine("The response sent by the server: " + response);

                    ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                    messageToSend.MessageText = response;

                    formatter.Serialize(stream, messageToSend);
                    stream.Flush();

                    if (messageFromClient.Type == "Message")
                        Server_class.serverDatabase.saveMessageToDb(messageFromClient);
                    if (messageFromClient.Type == "Logout")
                        break;

                    Console.WriteLine("Finished handling for: " + clientInDictionary.Key);
                }
                catch (Exception e)
                {

                    Console.WriteLine("Reading error: " + e.Message);
                }


            }
            stream.Close();
            Console.WriteLine("Thread terminated through Logout!");

        }

        private void sendUsersList()
        {
            List<string> list = new List<string>();

            foreach(var client in clientList)
            {
                list.Add(client.Key);
            }
            foreach (var client in clientList)
            {
                var stream = client.Value.GetStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, list);
                stream.Flush();
            }
        }

        public void ServerReceive(TcpClient clientn, string username)
        {
            byte[] data = new byte[1000];
            string text = null;
            while (true)
            {

                NetworkStream stream = clientn.GetStream(); //Gets The Stream of The Connection
                Console.WriteLine(username);
                stream.Read(data, 0, data.Length); //Receives Data 
                List<string> parts = (List<string>)ByteArrayToObject(data);
                Console.WriteLine(parts[0]);
                switch (parts[0])
                {
                    case "Connection Request":
                        Console.WriteLine("Connection Request");
                        announce("Connection Request", username, true);
                        break;

                    case "pChat":
                        Console.WriteLine("pChat");
                        break;
                }

                parts.Clear();

            }
        }
        public object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        public void announce(string msg, string uName, bool flag)
        {
            try
            {
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    if (flag)
                    {
                        chat.Add("gChat");
                        chat.Add(uName + " says : " + msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }
                    else
                    {
                        chat.Add("gChat");
                        chat.Add(msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    chat.Clear();
                }
            }
            catch (Exception er)
            {

            }
        }  //end broadcast function
        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        internal static void sendClientInvLoginMsg()
        {
            throw new NotImplementedException();
        }

        private static TcpClient acceptConnectionToClient(TcpListener listener)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine();
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
