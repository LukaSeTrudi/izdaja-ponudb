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
    public partial class DodajStrankoForm : Form
    {
        Form1 outer;
        public DodajStrankoForm(Form1 fm1)
        {
            InitializeComponent();
            outer = fm1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ime = textBox2.Text;
            string kontakt = textBox1.Text;
            int combo = comboBox1.SelectedIndex+1;
            if(ime.Length > 1 && kontakt.Length > 1 && combo > 0)
            {
                string smth = APIConnect.postData("dodaj-stranko.php", "ime=" + ime + "&kontakt=" + kontakt + "&tip=" + combo);
                outer.updatePodjetjaTable();
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
