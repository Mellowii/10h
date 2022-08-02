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

namespace CNPM_QLCH
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLSP qlsp = new QLSP();
            qlsp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLHD qlhd = new QLHD();
            qlhd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BCTK bctk = new BCTK();
            bctk.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QLNV qlnv = new QLNV();
            qlnv.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
