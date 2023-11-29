using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LojaGames
{
    public class Utilidades
    {
        public static void limparCampos(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is Bunifu.UI.WinForms.BunifuTextBox)
                {
                    ((Bunifu.UI.WinForms.BunifuTextBox)c).Text = "";
                }
                else if (c is Bunifu.UI.WinForms.BunifuDropdown)
                {
                    ((Bunifu.UI.WinForms.BunifuDropdown)c).SelectedIndex = -1;
                }
                if (c.HasChildren)
                {
                    limparCampos(c);
                }
            }
        }
    }
}
