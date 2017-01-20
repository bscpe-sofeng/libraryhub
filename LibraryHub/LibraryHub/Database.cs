using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Libraryhub
{
    public static class Database
    {
        
        static string database = "libraryhub";
        static string server = "localhost";
        static string port = "3306";
        static string username = "root";
        static string password = "nolsaranghe9";
        static string connectionString = "server=" + server + "; port=" + port + "; database=" + database + "; username=" + username + "; password=" + password + ";";
        public static MySqlConnection connection = null;
        

        static Database()
        {
            connection = new MySqlConnection(connectionString);
        }

        public static bool Open()
        {
            try
            {
                connection.Open(); 
                return true;
            }
            catch (Exception e)
            {
               
                return false;
            }
        }

        public static bool Close()
        {
            try
            {
                connection.Close(); //deconnect from database
                return true;
            }
            catch (Exception e)
            {
                //if error occur
                return false;
            }
        }
    }
}