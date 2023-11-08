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
    public partial class games : Form
    {
        public games()
        {
            InitializeComponent();
        }

        private void panelBtn_Desconectar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
