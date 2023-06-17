using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane
{
    public partial class Form2 : Form
    {
        string uname;
        public Form2(string username)
        {
            InitializeComponent();
            label1.Text = "Hoşgeldin " + username;
            uname = username;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            settingform settingform = new settingform(uname);
            settingform.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksForm booksForm = new BooksForm(uname);
            booksForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            myBooks myb = new myBooks(uname);
            myb.ShowDialog();
            this.Close();
        }
    }
}
