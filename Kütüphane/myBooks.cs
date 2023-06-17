using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Kütüphane.myclass;

namespace Kütüphane
{
    public partial class myBooks : Form
    {
        takenbook takenbook = new takenbook();
        string uname;
        public myBooks(string username)
        {
            InitializeComponent();
            label1.Text = "Hoşgeldin " + username;
            uname = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2(uname);
            f2.ShowDialog();
            this.Close();
        }

        public void loadData()
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT books.id, books.book_name, books.author, books.category FROM odunc_kitap JOIN books ON odunc_kitap.book_id = books.id WHERE user_id = (SELECT id FROM user WHERE username = '" + uname + "')";
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

        private void myBooks_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            takenbook.odunc_hakki_artir(uname);
            takenbook.iade(Convert.ToInt32(label2.Text));
            takenbook.stockArtır(Convert.ToInt32(label2.Text));
            MessageBox.Show("İade edildi.");
            loadData();
        }

        int indexRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            label2.Text = row.Cells[0].Value.ToString();
        }
    }
}
