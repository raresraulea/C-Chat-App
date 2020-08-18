using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Server
{
    class Database
    {
        public SQLiteConnection myConnection;
        //DataTable local = new DT;

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

        internal void checkUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
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
        public int AddUser(User user)
        {
            const string query = "INSERT INTO USERS(Username, Password) VALUES(@Username, @Password)";

            var args = new Dictionary<string, object>
            {
                 {"@Username", user.username},
                 {"@Password", user.password}
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

        public int DeleteUser(User user)
        {
            const string query = "Delete from USERS WHERE Username = @Username";

            var args = new Dictionary<string, object>
            {
                {"@Username", user.username}
            };

            return ExecuteWrite(query, args);
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

    }
}
