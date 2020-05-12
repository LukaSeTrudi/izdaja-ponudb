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
    public partial class UrediStoritev : Form
    {
        int user_id;
        string ponudba;
        string initStanje;
        Form1 fm;
        public UrediStoritev(Form1 _fm, string id, string storitev, string opis, string cena, string stranka, string stanje, int delavec)
        {
            ponudba = id;
            user_id = delavec;
            InitializeComponent();
            textBox2.Text = storitev;
            textBox3.Text = opis;
            textBox4.Text = cena;
            textBox5.Text = stranka;
            initStanje = stanje;
            comboBox1.SelectedItem = stanje;
            fm = _fm;
        }

        private void Spremeni_Click(object sender, EventArgs e)
        {
            string opis = textBox1.Text;
            if((string)comboBox1.SelectedItem != initStanje)
            {
                string sl = APIConnect.postData("uredi-ponudbo.php", "stanje="+comboBox1.SelectedItem+"&ponudba_id="+ponudba+"&spremenil_id="+user_id+"&opis="+opis+"&");
                try
                {
                    fm.updateStoritveTable();
                    fm.filter();
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            }
        }
    }
}
