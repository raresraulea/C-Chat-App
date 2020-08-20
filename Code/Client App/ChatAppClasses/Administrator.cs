using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppClasses
{
    public class Administrator : User
    {
        public void blockUser(User user)
        {
            Server_class.serverDatabase.BlockUser(user);
        }
        public void unblockUser(User user)
        {
            Server_class.serverDatabase.UnblockUser(user);
        }
        public void warnUser(User user)
        {

        }
        public void deleteUserAccount(User user)
        {
            Server_class.serverDatabase.DeleteUser(user);
        }

    }
}
