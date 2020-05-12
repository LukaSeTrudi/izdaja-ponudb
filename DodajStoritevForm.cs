using Newtonsoft.Json;
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
    public partial class DodajStoritevForm : Form
    {
        Form1 fm;
        public DodajStoritevForm(Form1 _fm)
        {
            InitializeComponent();
            fm = _fm;
            update();
        }

        private void update()
        {
            string dat = APIConnect.readData("dobi-stranke.php");
            Stranka[] stranke = JsonConvert.DeserializeObject<Stranka[]>(dat);
            comboBox1.Items.Clear();
            foreach (var stranka in stranke)
            {
                comboBox1.Items.Add(stranka.ime);
            }
            string stnj = APIConnect.readData("dobi-stanja.php");
            Stanje[] stanja = JsonConvert.DeserializeObject<Stanje[]>(stnj);
            comboBox2.Items.Clear();
            foreach(var st in stanja)
            {
                comboBox2.Items.Add(st.stanje);
            }
            comboBox2.SelectedIndex = 0;
            comboBox2.Enabled = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            string opis = textBox2.Text;
            string price = textBox3.Text;
            string stranka = comboBox1.SelectedItem.ToString();
            if(str.Length > 1 && opis.Length > 1 && price.Length > 0 && stranka.Length > 1)
            {
                string _s = APIConnect.postData("dodaj-ponudbo.php", "storitev=" + str + "&opis=" + opis + "&cena=" + price + "&izdal=" + 1 + "&stranka=" + stranka);
                Console.WriteLine(_s);
                fm.updateStoritveTable();
                this.Close();
            }
        }
    }
}
