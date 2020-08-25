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

        TcpClient client;
        String clNo;
        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        List<string> chat = new List<string>();

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
                    string username = messageFromClient.username;
                    //Message messageFromClient = new Message();
                    //messageFromClient.setText(Encoding.UTF8.GetString(buffer));
                    if (messageFromClient.Type == "Login")
                        Console.WriteLine(messageFromClient.username + " " + messageFromClient.password);

                    string response = handleIncomingMessage(messageFromClient);

                    networkStream.Write(Encoding.ASCII.GetBytes(response));
                    /* add to dictionary, listbox and send userList  */
                    clientList.Add(username, client);
                    //announce(username + " Joined ", username, false);

                    ////await Task.Delay(1000).ContinueWith(t => sendUsersList());
                    //streamWriter.Flush();
                    //streamWriter.Close();

                    var c = new Thread(() => ServerReceive(client, username));
                    c.Start();
                }
                catch (Exception e)
                {

                    Console.WriteLine("Failed to start..." + e.Message);
                }
            }
        }
        public void ServerReceive(TcpClient clientn, string username)
        {
            byte[] data = new byte[1000];
            string text = null;
            Console.WriteLine(username);
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
        public Object ByteArrayToObject(byte[] arrBytes)
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
                        //broadcastBytes = Encoding.ASCII.GetBytes("gChat|*|" + uName + " says : " + msg);

                        chat.Add("gChat");
                        chat.Add(uName + " says : " + msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }
                    else
                    {
                        //broadcastBytes = Encoding.ASCII.GetBytes("gChat|*|" + msg);

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
