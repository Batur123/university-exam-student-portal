using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace girisekrani
{
    public partial class OgretmenOgrenciGoster : Form
    {
        public OgretmenOgrenciGoster()
        {
            InitializeComponent();
        }

        static string conString = "Server=BATUR;Database=OBSVeritabani;Integrated Security=TRUE";
       
        SqlConnection baglanti = new SqlConnection(conString);
       

        private void OgretmenOgrenciGoster_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'oBSVeritabaniDataSet.ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter.Fill(this.oBSVeritabaniDataSet.ogrenci);
            // TODO: Bu kod satırı 'oBSVeritabaniDataSet.ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.

            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
        }

        private void kayitGetir()
        {
          
        }

        private void VeriGoster_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OgretmenAnaMenu a = new OgretmenAnaMenu();
            a.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
