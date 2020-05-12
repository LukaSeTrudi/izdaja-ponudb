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
    public partial class Zgodovina : Form
    {
        public Zgodovina(int id, string storitev, string opis, string cena, string stranka)
        {
            InitializeComponent();
            textBox1.Text = storitev;
            textBox2.Text = opis;
            textBox3.Text = cena;
            textBox4.Text = stranka;

            loadZgodovina(id);
        }
        public void loadZgodovina(int id)
        {
            string zg = APIConnect.postData("dobi-zgodovino.php", "id=" + id);
            Console.WriteLine(zg);
            ZgodovinaPonudba[] data = JsonConvert.DeserializeObject<ZgodovinaPonudba[]>(zg);
            dataGridView1.Rows.Clear();
            foreach(var k in data)
            {
                dataGridView1.Rows.Add(k.ime, k.stanje, k.opis, k.datum);
            }
        }
    }
}
