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
    class updatesettings : connection_class
    {
        public string password { set; get; }
        public string security_question { set; get; }

        public string security_answer { set; get; }
        public string email { set; get; }
        public string username { set; get; }    

        public bool updateUser()
        {
            bool check = false;
            connectdb.Open();
            
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE user SET password = @pass, security_question = @question, security_answer = @answer, email = @email WHERE username = @username";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = security_question;
                cmd.Parameters.Add("@answer", MySqlDbType.VarChar).Value = security_answer;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;

                cmd.ExecuteReader();
                connectdb.Close();
                check = true;
                
            }
            return check;
        }
    }
}
