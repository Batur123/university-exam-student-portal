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
    public partial class ProgramHakkinda : Form
    {
        public ProgramHakkinda()
        {
            InitializeComponent();
        }


        private void ProgramHakkinda_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SecimEkrani a = new SecimEkrani();
            a.Show();
            this.Hide();
        }
    }
}
