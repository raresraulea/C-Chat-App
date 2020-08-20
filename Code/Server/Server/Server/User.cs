
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Server
{
    public class User
    {
        public int ID;
        public string IP;
        public string username;
        public string password;
        public string accessLevel;
        public string name;
        static int idCount = 0;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public User()
        {
        }
        public void Login()
        {
            Server_class.handleLogin(this);
        }
        public void sendMessage(string messageText, User destinationUser)
        {
            Message msg = new Message(messageText, destinationUser.username);
            msg.Sender = this.username;

            //de trimis mesajul catre client

            Server_class.serverDatabase.saveMessageToDb(msg);

        }
        public void deleteMessage(string messageText)
        {
            Message msg = new Message(messageText);
            msg.Sender = this.username;
            Server_class.serverDatabase.DeleteMessageFromDb(msg);
        }
        public void deleteConversation(string partnerUsername)
        {
            Server_class.serverDatabase.DeleteConversation(this.username, partnerUsername);
        }
        public void getMessagesWith(User user)
        {
            List<Message> list = new List<Message>();
            list = Server_class.serverDatabase.getChatHistoryFromDb(this, user);
            //List<string> stringMessages = list.Where(x => x.GetType() == string)
            foreach (Message msg in list)
            {
                System.Console.WriteLine(msg.MessageText);
            }
        }
    }
}