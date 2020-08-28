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
                clientList.Add(messageFromClient.username, client);

            //getting the client for using it by username
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
                        messageFromClient = (ChatAppClasses.Message)formatter.Deserialize(stream);

                    string response = calculateResponseByMessageType(client, messageFromClient, ref flag_first);

                    Console.WriteLine("The response sent by the server: " + response);

                    sendMessageBackToClient(stream, formatter, response);

                    if (response == Constants.response_wrongCredentials)
                    {
                        removeClientFromOnlineUsers(client);
                        break;
                    }
                    
                    handleType_message(messageFromClient);
                    
                    if (messageFromClient.Type == Constants.messageType_logout || messageFromClient.Type == Constants.messageType_signUp)
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

        private void handleType_message(ChatAppClasses.Message messageFromClient)
        {
            if (messageFromClient.Type == Constants.messageType_broadcastMessage)
                messageFromClient.Type = Constants.messageType_message;

            if (messageFromClient.Type == Constants.messageType_message)
            {
                Console.WriteLine("Saving message to Database...");
                cropUsernameFromMessage(messageFromClient);
                Server_class.serverDatabase.saveMessageToDb(messageFromClient);
            }
        }


        private void removeClientFromOnlineUsers(TcpClient client)
        {
            var clientToRemove = clientList.First(dictionaryItem => dictionaryItem.Value == client);
            clientList.Remove(clientToRemove.Key);
        }

        private static void sendMessageBackToClient(NetworkStream stream, IFormatter formatter, string response)
        {
            ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
            messageToSend.MessageText = response;

            formatter.Serialize(stream, messageToSend);
            stream.Flush();
        }

        private string calculateResponseByMessageType(TcpClient client, ChatAppClasses.Message messageFromClient, ref bool flag_first)
        {
            string response;
            switch (messageFromClient.Type)
            {
                case Constants.messageType_connection:
                    response = "Connected";
                    flag_first = false;
                    break;

                case Constants.messageType_message:
                    ChatAppClasses.Message messageToBroadcast = new ChatAppClasses.Message();
                    messageToBroadcast = messageFromClient;
                    broadcastMessage(messageToBroadcast);
                    response = "Message handled!";
                    break;

                case Constants.messageType_login:
                    User user = new User(messageFromClient.username, messageFromClient.password);
                    response = handleLogin(user);
                    if (response == "Logged In!" || response == "Welcome, Admin!")
                        sendUsersList();
                    flag_first = false;
                    break;

                case Constants.messageType_logout:
                    var clientToBeRemoved = clientList.First(dictionaryItem => dictionaryItem.Value == client);
                    clientList.Remove(clientToBeRemoved.Key);
                    response = "Logged Out!";
                    sendUsersList();
                    break;

                case Constants.messageType_signUp:
                    response = handleSignUp(new User() { username = messageFromClient.username, password = messageFromClient.password });
                    var clientToRemove = clientList.First(dictionaryItem => dictionaryItem.Value == client);
                    clientList.Remove(clientToRemove.Key);
                    break;

                default:
                    response = "Error";
                    break;
            }

            return response;
        }

        private void cropUsernameFromMessage(ChatAppClasses.Message message)
        {
            string updatedMessageText = "";
            bool encounteredSpace = false;
            for (var i = 0; i < message.MessageText.Length; i++)
            {
                if (encounteredSpace)
                    updatedMessageText += message.MessageText[i];
                else if (message.MessageText[i] == ' ')
                    encounteredSpace = true;
            }
            message.MessageText = updatedMessageText;
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
        private void broadcastMessage(ChatAppClasses.Message messageToBroadcast)
        {
            messageToBroadcast.Type = "broadcastMessage";
            messageToBroadcast.MessageText = messageToBroadcast.username + ": " + messageToBroadcast.MessageText;
            foreach (var client in clientList)
            {
                var stream = client.Value.GetStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, messageToBroadcast);
                stream.Flush();
            }
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

        public string handleSignUp(User user)
        {
            SignUp signUp = SignUp.Instance;
            return SignUp.signUp(user);
        }

        
        public static void saveMessageToDB(ChatAppClasses.Message message)
        {
            serverDatabase.saveMessageToDb(message);
        }
       
    }
}
