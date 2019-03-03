using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girisekrani
{
    public partial class OgrenciOgretmenListesi : Form
    {
        public OgrenciOgretmenListesi()
        {
            InitializeComponent();
        }

        private void OgrenciOgretmenListesi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'oBSVeritabaniDataSet1.ogretim_gorevlisi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogretim_gorevlisiTableAdapter.Fill(this.oBSVeritabaniDataSet1.ogretim_gorevlisi);
            // TODO: Bu kod satırı 'obsdbDataSet2.ogretmenn' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrenciAnaMenu a = new OgrenciAnaMenu();
            a.Show();
            this.Hide();
        }
    }
}
