using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Kütüphane.myclass;
using System.Security.Cryptography;

namespace Kütüphane.myclass
{
    class takenbook : connection_class
    {
        
        public void odunc_al(int uid, int bid)
        {
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO odunc_kitap (user_id, book_id) VALUES (@uid, @bid)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = uid;
                cmd.Parameters.Add("bid", MySqlDbType.Int32).Value = bid;
                cmd.ExecuteReader();
                connectdb.Close();
                odunc_hakki_azalt(uid);
            }
        }

        public void odunc_hakki_azalt(int uid)
        {
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE user SET odunc_hakki = odunc_hakki -1 WHERE id = @uid";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = uid;
                
                cmd.ExecuteReader();
                connectdb.Close();

            }
        }

        public void odunc_hakki_artir(string username)
        {
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE user SET odunc_hakki = odunc_hakki +1 WHERE username = @user";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = username;

                cmd.ExecuteReader();
                connectdb.Close();

            }
        }
        
        public void stockArtır(int bid)
        {
            connectdb.Open();
            using(var cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE books SET stock = stock +1 WHERE id ="+bid;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;
                cmd.ExecuteReader();
                connectdb.Close();
            }
        }
        public void iade(int bid)
        {
            connectdb.Open();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM odunc_kitap WHERE book_id = "+bid;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;
                cmd.ExecuteReader();
                connectdb.Close();
            }
        }
    }
}
