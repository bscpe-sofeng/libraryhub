using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Libraryhub
{
    public class exists
    {
        public string username;
        public static exists exist(string username)
        {
            exists exist = null;
            exist = new exists();
            try
            {
                MySqlCommand myCommand = new MySqlCommand("SELECT * FROM account WHERE user = @user", Database.connection);
                myCommand.Prepare();
                myCommand.Parameters.AddWithValue("@user", username);

                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    username = reader["user"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //if reader is fail
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            return exist; // return user date 
        }
    }
}
