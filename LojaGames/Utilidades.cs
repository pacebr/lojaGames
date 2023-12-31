﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LojaGames
{
    public class Utilidades
    {
        public static void limparCampos(Control ctrl, params PictureBox[] pictureBox)
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
                else if (c is Bunifu.UI.WinForms.BunifuToggleSwitch)
                {
                    ((Bunifu.UI.WinForms.BunifuToggleSwitch)c).Checked = false;
                }
                else if (c is PictureBox && pictureBox.Contains((PictureBox)c))
                {
                    ((PictureBox)c).Image = null;
                }
                if (c.HasChildren)
                {
                    limparCampos(c, pictureBox);
                }
            }
        }
    }
}