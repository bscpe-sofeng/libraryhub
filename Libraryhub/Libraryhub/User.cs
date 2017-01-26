using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Libraryhub
{

    public class User
    {

        public string username;
        public string password;
        public string type;


        public static User login(string username, string password)
        {
            User user = null;
            user = new User();

            string query = "SELECT * FROM account WHERE user = @user AND pass = @pass";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, Database.connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                // make execute reader
                MySqlDataReader reader = cmd.ExecuteReader(); // commad reader data

                while (reader.Read())
                {
                    user.username = reader["user"].ToString(); // array reader index as field table name
                    user.password = reader["pass"].ToString();
                    user.type = reader["type"].ToString();

                }
                reader.Close(); // close reader

            }
            catch (Exception ex)
            {
                //if reader is fail
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            return user; // return user data
        }
        
    }
}


