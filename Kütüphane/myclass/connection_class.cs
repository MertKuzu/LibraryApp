using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Kütüphane.myclass
{
    class connection_class
    {
        public MySqlConnection connectdb;

        public connection_class()
        {
            string host = "localhost";
            string database = "kutuphane";
            string username = "root";
            string password = "Laj49f8j9wq6r9g6*";
            string port = "3306";
            string connection_string = "datasource="+host+"; database="+database+"; port="+port+"; username="+username+"; password="+password+"; SslMode = none;";

            connectdb = new MySqlConnection(connection_string);
        }
    }
}
