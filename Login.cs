using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IzdajaPonudb
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;

            string ob = APIConnect.postData("login.php", "username=" + user + "&password=" + pass);
            Console.WriteLine(ob);
            if(ob == "NO USER")
            {
                MessageBox.Show("INVALID USERNAME OR PASSWORD");
            } else
            {
                Form1 fm = new Form1(Convert.ToInt32(ob));
                fm.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register rs = new Register();
            rs.Show();
        }
    }
}
