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
    public partial class register_form : Form
    {
        connection_class con = new connection_class();
        register reg = new register();
        public register_form()
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
            reg.username = textBox1.Text;
            reg.password = textBox2.Text;
            reg.email = textBox3.Text;
            reg.security_question = comboBox1.Text;
            reg.security_question_answer = textBox5.Text;

            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Bazı alanlar boş!");
            }
            else
            {
                bool verify = reg.Register_User();
                if (verify)
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
