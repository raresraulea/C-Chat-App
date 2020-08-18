
using System.Threading;

namespace Server
{
    public class User
    {
        public int ID;
        public int IP;
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
        public void Login(string username, string password)
        {
            Server.handleLogin(username, password);
        }
        public void sendMessage(string messageText, User destinationUser)
        {
            Message msg = new Message(messageText, destinationUser.username);
            msg.Sender = this.username;
            Server.serverDatabase.saveMessageToDb(msg);
            
        }
    }
}