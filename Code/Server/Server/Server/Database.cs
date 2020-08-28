using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Linq;
using ChatAppClasses;

namespace Server
{
    public class Database
    {
        public SQLiteConnection myConnection;
        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                Console.WriteLine("Database file created");
            }
            myConnection.Open();
        }

        public int ExecuteWrite(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;

            using (var cmd = new SQLiteCommand(query, myConnection))
            {
                foreach (var pair in args)
                {
                    cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                }

                numberOfRowsAffected = cmd.ExecuteNonQuery();
            }

            return numberOfRowsAffected;
        }



        public DataTable ExecuteRead(string query, Dictionary<string, object> args)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;

            using (var cmd = new SQLiteCommand(query, myConnection))
            {
                foreach (KeyValuePair<string, object> entry in args)
                {
                    cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                }

                var da = new SQLiteDataAdapter(cmd);

                var dt = new DataTable();
                da.Fill(dt);

                da.Dispose();
                return dt;
            }
        }
        public int AddUser(User user)
        {
            const string query = "INSERT INTO USERS(Username, Password,AccessLevel) VALUES(@Username, @Password, @AccessLevel)";

            if (user.accessLevel != "User")
                user.accessLevel = "User";
            var args = new Dictionary<string, object>
            {
                 {"@Username", user.username},
                 {"@AccessLevel", user.accessLevel},
                 {"@Password", user.password}
            };

            return ExecuteWrite(query, args);
        }
        public int AddAdministrator(User user)
        {
            const string query = "INSERT INTO USERS(Username, Password, AccessLevel) VALUES(@Username, @Password, @AccessLevel)";

            var args = new Dictionary<string, object>
            {
                 {"@Username", user.username},
                 {"@AccessLevel", "Admin"},
                 {"@Password", user.password}
            };

            return ExecuteWrite(query, args);
        }
        public int DeleteUser(User user)
        {
            const string query = "Delete from USERS WHERE Username = @Username";

            var args = new Dictionary<string, object>
            {
                {"@Username", user.username}
            };

            return ExecuteWrite(query, args);
        }
        public int EditPassword(User user, string newPassword)
        {
            const string query = "UPDATE USERS SET PAssword = @Password WHERE Username = @Username";

            var args = new Dictionary<string, object>
            {
                {"@Username", user.username},
                {"@Password", newPassword}
            };

            return ExecuteWrite(query, args);
        }
        public User GetUserById(int ID)
        {
            var query = "SELECT * FROM USERS WHERE ID = @ID";

            var args = new Dictionary<string, object>
            {
                {"@ID", ID}
            };

            DataTable dt = ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            var user = new User()
            {
                username = Convert.ToString(dt.Rows[0]["Username"]),
                password = Convert.ToString(dt.Rows[0]["Password"])
            };

            return user;
        }
        public bool usernameAvailable(string username)
        {
            var query = "SELECT * FROM USERS WHERE Username = @Username";

            var args = new Dictionary<string, object>
            {
                {"@Username", username}
            };

            DataTable dt = ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return true;
            }

            return false;
        }
        public bool checkCredentials(string username, string password)
        {
            var query = "SELECT * FROM USERS WHERE Username = @Username AND Password = @Password";

            var args = new Dictionary<string, object>
            {
                {"@Username", username},
                {"@Password", password}
            };

            DataTable dt = ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }
        internal bool verifyAdmin(string username, string password)
        {
            var query = "SELECT * FROM USERS WHERE Username = @Username AND Password = @Password AND AccessLevel = @AccessLevel";

            var args = new Dictionary<string, object>
            {
                {"@Username", username},
                {"@AccessLevel", "Admin"},
                {"@Password", password}
            };

            DataTable dt = ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }
           
        public int saveMessageToDb(ChatAppClasses.Message message)
        {
            const string query = "INSERT INTO MESSAGES(Message, Sender, Receiver) VALUES(@Message, @Sender, @Receiver)";

            var args = new Dictionary<string, object>
            {
                 {"@Message", message.MessageText},
                 {"@Receiver", message.Receiver},
                 {"@Sender", message.username}
            };

            return ExecuteWrite(query, args);
        }
        public int DeleteMessageFromDb(Message message)
        {
            const string query = "Delete from MESSAGES WHERE Message = @Message";

            var args = new Dictionary<string, object>
            {
                {"@Message", message.MessageText}
            };

            return ExecuteWrite(query, args);

        }
        public int DeleteConversation(string participant1, string participant2)
        {
            const string query = "Delete from MESSAGES WHERE Sender = @Sender AND Receiver = @Receiver";

            var args = new Dictionary<string, object>
            {
                {"@Receiver", participant2},
                {"@Sender", participant1}
            };

            return ExecuteWrite(query, args);
        }
        public List<Message> getChatHistoryFromDb(User participant1, User participant2)
        {
            var query = "SELECT * FROM MESSAGES WHERE Sender = @Sender AND Receiver = @Receiver";

            var args = new Dictionary<string, object>
            {
                {"@Sender", participant1.username},
                {"@Receiver", participant2.username}
            };

            List<Message> messageList = new List<Message>();
            DataTable dt = ExecuteRead(query, args);
            if (dt == null || dt.Rows.Count == 0)
            {

            }
            messageList = (from DataRow dr in dt.Rows
                           select new Message()
                           {
                               MessageText = dr["Message"].ToString()
                           }
                           ).ToList();

            return messageList;
        }

        public int BlockUser(User user)
        {
            const string query = "UPDATE USERS SET Active = @Active WHERE Username = @Username AND Password = @Password";

            var args = new Dictionary<string, object>
            {
                {"@Username", user.username},
                {"@Password", user.password},
                {"@Active", "No"}
            };

            return ExecuteWrite(query, args);
        }
        public int UnblockUser(User user)
        {
            const string query = "UPDATE USERS SET Active = @Active WHERE Username = @Username AND Password = @Password";

            var args = new Dictionary<string, object>
            {
                {"@Username", user.username},
                {"@Password", user.password},
                {"@Active", "Yes"}
            };

            return ExecuteWrite(query, args);
        }
    }
}
