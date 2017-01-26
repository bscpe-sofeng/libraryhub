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
        
        internal static string database = "libraryhub";
        internal static string server = "localhost";
        internal static string port = "3306";
        internal static string username = "root";
        internal static string password = "nolsaranghe9";
        internal static string connectionString = "server=" + server + "; port=" + port + "; database=" + database + "; username=" + username + "; password=" + password + ";";
        internal static MySqlConnection connection = null;


        static Database()
        {
            connection = new MySqlConnection(connectionString);
        }

        internal static bool Open()
        {
            try
            {
                connection.Open(); 
                return true;
            }
            catch (Exception)
            {
               
                return false;
            }
        }

        internal static bool Close()
        {
            try
            {
                connection.Close(); //deconnect from database
                return true;
            }
            catch (Exception)
            {
                //if error occur
                return false;
            }
        }
    }
}