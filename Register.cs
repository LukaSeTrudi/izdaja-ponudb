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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ime = textBox1.Text;
            string user = textBox2.Text;
            string pass = textBox3.Text;
            string email = textBox4.Text;
            string phone = textBox5.Text;
            if(ime.Length > 0 && user.Length > 0 && pass.Length > 0 && email.Length > 0)
            {
                APIConnect.postData("registration.php", "name=" + ime + "&username=" + user + "&password=" + pass + "&email=" + email + "&phone=" + phone);
                this.Close();
            }
        }
    }
}
