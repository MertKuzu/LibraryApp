using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Kütüphane.myclass;
using System.Windows.Forms;


namespace Kütüphane.myclass
{
    class booksqueries : connection_class
    {
        public string bookname { set; get; }
        public string author { set; get; }
        public string isbn { set; get; }
        public string volume { set; get; }
        public string category { set; get; }
        public string description { set; get; }
        public int stock { set; get; }

        public int id { set; get; }

        public bool Insert_book()
        {
            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO books (book_name, author, ISBN, volume, category, description, stock) VALUES (@bookn, @author, @isbn, @volume, @category, @description, @stock)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;
                
                cmd.Parameters.Add("@bookn", MySqlDbType.VarChar).Value = bookname;
                cmd.Parameters.Add("@author", MySqlDbType.VarChar).Value=author;
                cmd.Parameters.Add("@isbn", MySqlDbType.VarChar).Value = isbn;
                cmd.Parameters.Add("@volume", MySqlDbType.VarChar).Value = volume;
                cmd.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;
                cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
                cmd.Parameters.Add("@stock", MySqlDbType.Int32 ).Value = stock;
                
                try
                {
                    rd = cmd.ExecuteReader();
                    check = true;
                    MessageBox.Show("Eklendi");
                    connectdb.Close();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Hata 1"+ ex);
                    connectdb.Close();
                }
            }
            return check;
        }

        public bool update_book()
        {
            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE books SET book_name=@bookn, author=@author, ISBN=@isbn, volume=@volume, category=@category, description=@description, stock=@stock WHERE id =@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                cmd.Parameters.Add("@bookn", MySqlDbType.VarChar).Value = bookname;
                cmd.Parameters.Add("@author", MySqlDbType.VarChar).Value = author;
                cmd.Parameters.Add("@isbn", MySqlDbType.VarChar).Value = isbn;
                cmd.Parameters.Add("@volume", MySqlDbType.VarChar).Value = volume;
                cmd.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;
                cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
                cmd.Parameters.Add("@stock", MySqlDbType.Int32).Value = stock;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                try
                {
                    rd = cmd.ExecuteReader();
                    check = true;
                    MessageBox.Show("Güncellendi");
                    connectdb.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 1" + ex);
                    connectdb.Close();
                }
            }
            return check;
        }

        public bool delete_book()
        {
            bool check = false;
            connectdb.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM books WHERE id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;

                
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                try
                {
                    rd = cmd.ExecuteReader();
                    check = true;
                    MessageBox.Show("Silindi");
                    connectdb.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 1" + ex);
                    connectdb.Close();
                }
            }
            return check;
        }
        public void stock_update(int id)
        {
            
            connectdb.Open();
            
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE books SET stock = stock - 1 WHERE id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectdb;


                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                
                cmd.ExecuteReader();
                
                    
                connectdb.Close();
               
            }
            
        }
    }
}
