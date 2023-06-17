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
    class register : connection_class
    {
        public string username { set; get; }
        public string password { set; get; }
        public string email { set; get; }
        public string security_question { set; get; }
        public string security_question_answer { set; get; }

        public bool Register_User()
        {
            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;
            using(MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO user (username, password, security_question, security_answer, email, odunc_hakki) VALUES (@user, @pass, @question, @answer, @email, 3)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;
                
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@question", MySqlDbType.VarChar).Value = security_question;
                cmd.Parameters.Add("@answer", MySqlDbType.VarChar).Value = security_question_answer;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

                try
                {
                    rd = cmd.ExecuteReader();
                    check = true;
                    MessageBox.Show("Üyelik başarılı, lütfen giriş yapın.");
                    connectdb.Close();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Var olan üyelik!");
                    connectdb.Close();
                }

            }
            return check;
        }
    }
}
