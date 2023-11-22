using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaGames
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuProgressBar1.Value = bunifuProgressBar1.Value + 3;
            label2.Text = bunifuProgressBar1.Value.ToString() + "%";

            if (bunifuProgressBar1.Value >= 99)
            {
                timer1.Enabled = false;
                new login().Show();
                this.Hide();
            }
        }
    }
}
