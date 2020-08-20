
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ChatAppClasses
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
        
    }
}