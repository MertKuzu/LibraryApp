using MySql.Data.MySqlClient;
using Kütüphane.myclass;

namespace Kütüphane
{
    public partial class Form1 : Form
    {
        connection_class con = new connection_class();
        acounts acc = new acounts();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acc.username = textBox1.Text;
            acc.password = textBox2.Text;
            bool verify = acc.Validate_User();
            if (verify)
            {
                if(acc.username == "admin" &&  acc.password == "admin")
                {
                    this.Hide();
                    adminpanel admin = new adminpanel();
                    admin.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.Hide();
                    Form2 form2 = new Form2(acc.username);
                    form2.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya parola hatalı!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register_form f2 = new register_form();
            f2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            reset_password f3 = new reset_password();
            f3.ShowDialog();
            this.Close();
        }
    }
}