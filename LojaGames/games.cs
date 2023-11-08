using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaGames.Resources;

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

        private void panelBtn_Games_Click(object sender, EventArgs e)
        {
            Refresh();
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

        private void button1_Click(object sender, EventArgs e)
        {
            menu formmenu = new menu();
            formmenu.ShowDialog();
        }

        private void panelBtn_Users_Click(object sender, EventArgs e)
        {
            Visible = false;
            users formusers = new users();
            formusers.ShowDialog();
        }

        private void panelBtn_Dashboard_Click(object sender, EventArgs e)
        {
            Visible = false;
            dashboard formdashboard = new dashboard();
            formdashboard.ShowDialog();
        }
    }
}
