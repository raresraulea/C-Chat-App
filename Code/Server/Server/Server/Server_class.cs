using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using ChatAppClasses;

namespace Server
{
    public class Server_class
    {
        public static Database serverDatabase;
        public static List<User> onlineUsers = new List<User>();

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
            onlineUsers.Clear();
            while (true)
            {
                Console.WriteLine("Waiting for connection...");
                TcpClient client = acceptConnectionToClient(listener);

                NetworkStream networkStream = client.GetStream();
                StreamReader streamReader = new StreamReader(client.GetStream());
                StreamWriter streamWriter = new StreamWriter(client.GetStream());
                IFormatter formatter = new BinaryFormatter();

                try
                {
                    byte[] buffer = new byte[1024];
                    //networkStream.Read(buffer);
                    ChatAppClasses.Message messageFromClient = (ChatAppClasses.Message)formatter.Deserialize(networkStream);
                    //Message messageFromClient = new Message();
                    //messageFromClient.setText(Encoding.UTF8.GetString(buffer));
                    if(messageFromClient.Type == "Login")
                        Console.WriteLine(messageFromClient.username + " " + messageFromClient.password);
                    
                    string  response = handleIncomingMessage(messageFromClient);
                    
                    networkStream.Write(Encoding.ASCII.GetBytes(response));
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine("Failed to start..." + e.Message);
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
