using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kütüphane.myclass;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Kütüphane
{
    public partial class BooksForm : Form
    {
        string uname;
        int control, uid;
        booksqueries queries = new booksqueries();
        takenbook takenbook = new takenbook();
        public BooksForm(string username)
        {
            InitializeComponent();
            uname = username;
            label1.Text = "Hoşgeldin " + username;
            getUserId(username);
            totalBooks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2(uname);
            form2.ShowDialog();
            this.Close();
        }

        public void totalBooks()
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT * FROM total_books";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Connection = grid.connectdb;
                MySqlDataReader rd = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rd); var rows = dt.AsEnumerable().ToArray();
                label7.Text = rows[0]["total"].ToString();
                
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
        public void getUserId(string username)
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT id, odunc_hakki FROM user WHERE username = '" + username + "'";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Connection = grid.connectdb;
                MySqlDataReader rd = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rd); var rows = dt.AsEnumerable().ToArray();
                label3.Text = rows[0]["id"].ToString();
                label4.Text = rows[0]["odunc_hakki"].ToString();
            }
            else
            {
                MessageBox.Show("Get user info error");
            }
        }
        public void loadData()
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT * FROM books WHERE stock > 0";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = grid.connectdb;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dataGridView1.DataSource = bindingSource;

                grid.close_db();
            }
            else
            {
                MessageBox.Show("Database error");
            }
        }

        public void loadBooks(string category)
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT * FROM books WHERE stock > 0 AND category = '" + category + "'";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = grid.connectdb;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dataGridView1.DataSource = bindingSource;

                grid.close_db();
            }
            else
            {
                MessageBox.Show("Database error");
            }
        }

        public void searchBook(string letter)
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT * FROM books WHERE book_name LIKE '%" + letter + "%'";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = grid.connectdb;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dataGridView1.DataSource = bindingSource;

                grid.close_db();
            }
            else
            {
                MessageBox.Show("Database error");
            }
        }

        public void searchAuthor(string letter)
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT * FROM books WHERE author LIKE '%" + letter + "%'";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = grid.connectdb;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dataGridView1.DataSource = bindingSource;

                grid.close_db();
            }
            else
            {
                MessageBox.Show("Database error");
            }
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            loadData();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadBooks("Edebiyat");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadBooks("Felsefe");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadBooks("Siyaset");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadBooks("Ekonomi");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadBooks("Bilim");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            loadBooks("Kişisel Gelişim");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadBooks("Tarih");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            control = 1;
            textBox1.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            control = 2;
            textBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (control == 1)
            {
                searchBook(textBox1.Text);
            }
            else if (control == 2)
            {
                searchAuthor(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Search error");
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {

            if (label4.Text != "0")
            {
                int id = Convert.ToInt32(textBox2.Text);
                queries.stock_update(id);
                var uid = Convert.ToInt32(label3.Text);

                takenbook.odunc_al(uid, id);
                MessageBox.Show("Kitap ödünç alındı");
                getUserId(uname);
                loadData();
                totalBooks();
            }
            else
            {
                MessageBox.Show("Ödünç alma hakkınız kalmadı!");
            }


        }

        int indexRow;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[7].Value.ToString();
        }
    }
}
