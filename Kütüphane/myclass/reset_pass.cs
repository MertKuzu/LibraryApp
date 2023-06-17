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
    class reset_pass : connection_class
    {

        public string security_question { set; get; }
        public string security_question_answer { set; get; }

        public string email { set; get; }
        public string new_password { set; get; }

        
        public bool Reset_password()
        {
            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE user SET password = @newpass WHERE email=@email AND security_question = @question AND security_answer = @answer";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = security_question;
                cmd.Parameters.Add("@answer", MySqlDbType.VarChar).Value = security_question_answer;
                cmd.Parameters.Add("@newpass", MySqlDbType.VarChar).Value = new_password;
                
                try
                {
                    rd = cmd.ExecuteReader();
                    check = true;
                    MessageBox.Show("Parola başarılı bir şekilde sıfırlandı.");
                    connectdb.Close();
                }
                catch
                {
                    MessageBox.Show("Beklenmedik bir hata!");
                    connectdb.Close();
                }
                
            }
            return check;
        }

    }
}
