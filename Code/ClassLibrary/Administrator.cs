using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Administrator : User
    {
        public void blockUser(User user) 
        {
            Server.serverDatabase.BlockUser(user);
        }
        public void unblockUser(User user)
        {
            Server.serverDatabase.UnblockUser(user);
        }
        public void warnUser(User user)
        {

        }
        public void deleteUserAccount(User user)
        {
            Server.serverDatabase.DeleteUser(user);
        }

    }
}
