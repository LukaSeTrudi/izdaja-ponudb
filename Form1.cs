using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IzdajaPonudb
{
    public partial class Form1 : Form
    {
        int user_id;
        public Form1(int us)
        {
            InitializeComponent();
            user_id = us;
            updateStoritveTable();
            initIsci();
        }
        private void initIsci()
        {
            string dat = APIConnect.readData("dobi-stranke.php");
            Stranka[] stranke = JsonConvert.DeserializeObject<Stranka[]>(dat);
            comboBox1.Items.Clear();
            foreach (var stranka in stranke)
            {
                comboBox1.Items.Add(stranka.ime);
            }

            string sd = APIConnect.readData("dobi-stranke.php");
            Delavec[] delavci = JsonConvert.DeserializeObject<Delavec[]>(sd);
            comboBox2.Items.Clear();
            foreach (var stranka in delavci)
            {
                comboBox2.Items.Add(stranka.ime);
            }

            string stnj = APIConnect.readData("dobi-stanja.php");
            Stanje[] stanja = JsonConvert.DeserializeObject<Stanje[]>(stnj);
            comboBox3.Items.Clear();
            foreach (var st in stanja)
            {
                comboBox3.Items.Add(st.stanje);
            }

            filter();
        }
        private void changedTab(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage5) // podjetja
            {
                updatePodjetjaTable();
            }
        }
        public void updateStoritveTable()
        {
            dataGridView2.Rows.Clear();
            string dat = APIConnect.readData("dobi-ponudbe.php");
            Ponudba[] data = JsonConvert.DeserializeObject<Ponudba[]>(dat);
            dataGridView2.Rows.Clear();
            foreach (var d in data)
            {
                dataGridView2.Rows.Add(d.id, d.storitev, d.opis, d.cena ,d.datum, d.stranka_ime, d.delavec_ime, d.stanje);
            }
        }
        public void updatePodjetjaTable()
        {
            dataGridView1.Rows.Clear();
            string dat = APIConnect.readData("dobi-stranke.php");
            Stranka[] stranke = JsonConvert.DeserializeObject<Stranka[]>(dat);
            foreach(var stranka in stranke){
                dataGridView1.Rows.Add(stranka.id, stranka.ime, stranka.kontakt, stranka.tip);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Dodaj stranko gumb
        {
            DodajStrankoForm df = new DodajStrankoForm(this);
            df.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if(id > 0)
            {
                string dat = APIConnect.postData("zbrisi-stranko.php", "id="+id);
                updatePodjetjaTable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodajStoritevForm df1 = new DodajStoritevForm(this);
            df1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UrediStoritev us = new UrediStoritev(this, dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString(), dataGridView2.CurrentRow.Cells[2].Value.ToString(),
                dataGridView2.CurrentRow.Cells[3].Value.ToString(), dataGridView2.CurrentRow.Cells[5].Value.ToString(), dataGridView2.CurrentRow.Cells[7].Value.ToString(), user_id);
            us.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Zgodovina zg = new Zgodovina(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), dataGridView2.CurrentRow.Cells[1].Value.ToString(), dataGridView2.CurrentRow.Cells[2].Value.ToString(),
                dataGridView2.CurrentRow.Cells[3].Value.ToString(), dataGridView2.CurrentRow.Cells[5].Value.ToString());
            zg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                APIConnect.ToCsV(dataGridView2, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                APIConnect.ToCsV(dataGridView3, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }
        public void filter()
        {
            string storitve = textBox1.Text;
            string stranka = comboBox1.Text;
            string delavec = comboBox2.Text;
            string stanje = comboBox3.Text;
            string neki = APIConnect.postData("dobi-ponudbe.php", "filter=neki&storitev=" + storitve + "&stranka=" + stranka + "&delavec=" + delavec + "&stanje=" + stanje);
            try
            {
                Ponudba[] data = JsonConvert.DeserializeObject<Ponudba[]>(neki);
                dataGridView3.Rows.Clear();
                foreach (var d in data)
                {
                    dataGridView3.Rows.Add(d.id, d.storitev, d.opis, d.cena, d.datum, d.stranka_ime, d.delavec_ime, d.stanje);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                UrediStoritev us = new UrediStoritev(this, dataGridView3.CurrentRow.Cells[0].Value.ToString(), dataGridView3.CurrentRow.Cells[1].Value.ToString(), dataGridView3.CurrentRow.Cells[2].Value.ToString(),
                    dataGridView3.CurrentRow.Cells[3].Value.ToString(), dataGridView3.CurrentRow.Cells[5].Value.ToString(), dataGridView3.CurrentRow.Cells[7].Value.ToString(), user_id);
                us.Show();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Zgodovina zg = new Zgodovina(Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value), dataGridView3.CurrentRow.Cells[1].Value.ToString(), dataGridView3.CurrentRow.Cells[2].Value.ToString(),
                    dataGridView3.CurrentRow.Cells[3].Value.ToString(), dataGridView3.CurrentRow.Cells[5].Value.ToString());
                zg.Show();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
