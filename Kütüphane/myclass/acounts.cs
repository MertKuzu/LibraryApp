using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Kütüphane.myclass;

namespace Kütüphane.myclass
{
    class acounts : connection_class
    {
        public string username { set; get; }
        public string password { set; get; }

        public bool Validate_User()
        {
            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;
            using (var cmd  = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM user WHERE username=@user AND password=@pass";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    MessageBox.Show("Giriş başarılı");
                }

                connectdb.Close();
            }

            return check;
        }
    }
}
