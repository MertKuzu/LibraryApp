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
    
    public partial class reset_password : Form
    {
        connection_class con = new connection_class();
        reset_pass res = new reset_pass();
        public reset_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res.security_question = comboBox1.Text;
            res.security_question_answer = textBox3.Text;
            res.email = textBox1.Text;
            res.new_password = textBox2.Text;

            if(comboBox1.Text == "" || textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurun!");
            }
            else
            {
                bool verify = res.Reset_password();
                if(verify)
                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Beklenmedik bir hata meydana geldi.");
                }
            }
        }
    }
}
