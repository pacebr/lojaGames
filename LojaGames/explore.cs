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
    public partial class explore : Form
    {
        public explore()
        {
            InitializeComponent();
            btnEntrar.Parent = pictureBox1;
            btnExplorar.Parent = pictureBox1;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            new login().Show();
            Visible = false;
        }
    }
}
