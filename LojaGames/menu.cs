using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaGames.Resources
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void panelBtn_Games_MouseEnter(object sender, EventArgs e)
        {
            panelBtn_Games.BackColor = Color.Green;
        }

        private void panelBtn_Games_MouseLeave(object sender, EventArgs e)
        {
            panelBtn_Games.BackColor = Color.DarkSlateBlue;
        }

        private void panelBtn_Users_MouseEnter(object sender, EventArgs e)
        {
            panelBtn_Users.BackColor = Color.Green;
        }

        private void panelBtn_Users_MouseLeave(object sender, EventArgs e)
        {
            panelBtn_Users.BackColor = Color.DarkSlateBlue;
        }

        private void panelBtn_Dashboard_MouseEnter(object sender, EventArgs e)
        {
            panelBtn_Dashboard.BackColor = Color.Green;
        }

        private void panelBtn_Dashboard_MouseLeave(object sender, EventArgs e)
        {
            panelBtn_Dashboard.BackColor = Color.DarkSlateBlue;
        }

        private void lblGames_MouseEnter(object sender, EventArgs e)
        {
            panelBtn_Games.BackColor = Color.Green;
        }

        private void lblUsers_MouseEnter(object sender, EventArgs e)
        {
            panelBtn_Users.BackColor = Color.Green;
        }

        private void lblDashboard_MouseEnter(object sender, EventArgs e)
        {
            panelBtn_Dashboard.BackColor = Color.Green;
        }

        private void panelBtn_Desconectar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelBtn_Games_Click(object sender, EventArgs e)
        {
            Visible = false;
            games formgames = new games();
            formgames.ShowDialog();
        }
    }
}
