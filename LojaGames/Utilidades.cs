using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace LojaGames
{
    public class Utilidades
    {
        public static void limparCampos(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is BunifuTextBox)
                {
                    c.Text = "";
                }
                else if (c is BunifuDropdown)
                {
                    ((BunifuDropdown)(c)).SelectedItem = String.Empty;
                }
                if (c.HasChildren)
                {
                    limparCampos(c);
                }
            }
        }
    }
}
