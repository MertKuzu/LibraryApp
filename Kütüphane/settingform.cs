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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Kütüphane
{
    public partial class settingform : Form
    {
        string username;
        updatesettings updatesettings = new updatesettings();
        public settingform(string uname)
        {
            InitializeComponent();
            label1.Text = "Hoşgeldin " + uname;
            username = uname;
            getUserInfo(uname);
        }

        public void getUserInfo(string username)
        {
            var grid = new datagrid();
            if (grid.connect_db())
            {
                string query = "SELECT password, security_question, security_answer, email FROM user WHERE username = '" + username + "'";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Connection = grid.connectdb;
                MySqlDataReader rd = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(rd); var rows = dt.AsEnumerable().ToArray();
                textBox1.Text = rows[0]["password"].ToString();
                comboBox1.Text = rows[0]["security_question"].ToString();
                textBox2.Text = rows[0]["security_answer"].ToString();
                textBox3.Text = rows[0]["email"].ToString();
            }
            else
            {
                MessageBox.Show("Get user info error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2(username);
            form2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatesettings.username = username;
            updatesettings.password = textBox1.Text;
            updatesettings.security_question = comboBox1.Text;
            updatesettings.security_answer = textBox2.Text;
            updatesettings.email = textBox3.Text;

            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayın!");
            }
            else
            {
                bool verify = updatesettings.updateUser();
                if(verify)
                {
                    MessageBox.Show("Güncellendi");
                }
                else
                {
                    MessageBox.Show("Hata meydana geldi");
                }
                
            }
        }
    }
}
