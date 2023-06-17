using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using Kütüphane.myclass;
using MySql.Data.MySqlClient;

namespace Kütüphane.myclass
{
    internal class datagrid : connection_class
    {
        
        public bool connect_db()
        {
            try
            {
                connectdb.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool close_db()
        {
            try
            {
                connectdb.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
