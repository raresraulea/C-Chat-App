
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
    }
}