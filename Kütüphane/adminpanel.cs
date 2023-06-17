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


namespace Kütüphane
{
    public partial class adminpanel : Form
    {
        booksqueries query = new booksqueries();



        public adminpanel()
        {
            InitializeComponent();


        }


        private void adminpanel_Load(object sender, EventArgs e)
        {
            loadData();

        }

        public void loadData()
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "CALL showBooks()";
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

        private void button1_Click(object sender, EventArgs e)
        {
            query.bookname = textBox1.Text;
            query.author = textBox2.Text;
            query.isbn = textBox3.Text;
            query.volume = textBox4.Text;
            query.category = comboBox1.Text;
            query.description = textBox5.Text;
            query.stock = Convert.ToInt32(textBox6.Text);

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurun!");
            }
            else
            {
                bool verify = query.Insert_book();
                if (verify)
                {
                    MessageBox.Show("Veri eklendi");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Hata 2 ");
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        int indexRow;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[5].Value.ToString();
            textBox5.Text = row.Cells[6].Value.ToString();
            textBox6.Text = row.Cells[7].Value.ToString();
            textBox7.Text = row.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            query.bookname = textBox1.Text;
            query.author = textBox2.Text;
            query.isbn = textBox3.Text;
            query.volume = textBox4.Text;
            query.category = comboBox1.Text;
            query.description = textBox5.Text;
            query.stock = Convert.ToInt32(textBox6.Text);
            query.id = Convert.ToInt32(textBox7.Text);

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurun!");
            }
            else
            {
                bool verify = query.update_book();
                if (verify)
                {
                    MessageBox.Show("Güncellendi");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Hata 2 ");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            query.id = Convert.ToInt32(textBox7.Text);
            bool verify = query.delete_book();
            if (verify)
            {
                MessageBox.Show("Silindi");
                loadData();
            }
            else
            {
                MessageBox.Show("Hata 2 ");
            }
        }
    }
}
