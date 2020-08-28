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

        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        static int clientID = 1;

        public void connectToDatabase(Database database)
        {
            serverDatabase = database;
            Console.WriteLine("Connected to Database...");
        }
        public void run()
        {
            clientList.Clear();

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

            KeyValuePair<string, TcpClient> clientInDictionary;
            clientInDictionary = clientList.First(dictionaryItem => dictionaryItem.Value == client);
            Console.WriteLine("Handling " + clientInDictionary.Key);


            while (true)
            {
                try
                {
                    stream = client.GetStream();
                    StreamWriter streamWriter = new StreamWriter(stream);

                    if (!flag_first)
                    {
                        messageFromClient = (ChatAppClasses.Message)formatter.Deserialize(stream);
                        Console.WriteLine("Update Message" + messageFromClient.Type);

                    }

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
                            var clientToRemove = clientList.First(dictionaryItem => dictionaryItem.Value == client);
                            clientList.Remove(clientToRemove.Key);
                            break;

                        default:
                            response = "Error";
                            break;
                    }

                    Console.WriteLine("The response sent by the server: " + response);

                    ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                    messageToSend.MessageText = response;

                    formatter.Serialize(stream, messageToSend);
                    stream.Flush();
                    
                    if (response == "Wrong Credentials!")
                    {
                        Thread.Sleep(300);
                        var clientToRemove = clientList.First(dictionaryItem => dictionaryItem.Value == client);
                        clientList.Remove(clientToRemove.Key);
                        break;
                    }
                    if (messageFromClient.Type == "Message")
                        Server_class.serverDatabase.saveMessageToDb(messageFromClient);
                    if (messageFromClient.Type == "Logout" || messageFromClient.Type == "SignUp")
                    {
                        stream.Close();
                        break;
                    }

                    Console.WriteLine("Finished handling for: " + clientInDictionary.Key);
                }
                catch (Exception e)
                {

                    Console.WriteLine("Reading error: " + e.Message);
                }


            }
            
            Console.WriteLine("Thread terminated through Logout!");

        }

        private void sendUsersList()
        {
            List<string> list = new List<string>();

            foreach (var client in clientList)
            {
                list.Add(client.Key);
            }
            ChatAppClasses.Message onlineUsersList = new ChatAppClasses.Message();
            onlineUsersList.Type = "List";
            onlineUsersList.onlineUser = list;
            foreach (var client in clientList)
            {
                var stream = client.Value.GetStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, onlineUsersList);
                stream.Flush();
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

            return loginResponse;
        }

        public static void sendChatHistoryToClient()
        {

        }
        public string handleSignUp(User user)
        {
            SignUp signUp = SignUp.Instance;
            return SignUp.signUp(user);
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
