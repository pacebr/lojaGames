﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LojaGames.Properties;
using System.IO;
using System.Threading;
using Utilities.BunifuTextBox.Transitions;

namespace LojaGames
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            txtUsuarioCliente.Select();
        }

        private void btnEntrarCliente_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioCliente.Text;
            string senha = txtSenhaCliente.Text;

            bool loginSucesso = ControleCliente.VerificarCredenciais(usuario, senha);

            if (loginSucesso)
            {
                new menu().Show();
                this.Close();
                Conexao.Fechar();
            }
            else
            {
                Conexao.Fechar();
                bunifuSnackbar1.Show(
                   this,
                   "Usuário ou senha incorretos.",
                   Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
            txtUsuarioCliente.Clear();
            txtSenhaCliente.Clear();
        }

        private void btnEntrarFunc_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioFunc.Text;
            string senha = txtSenhaFunc.Text;

            bool loginSucesso = ControleFuncionario.VerificarCredenciais(usuario, senha);

            if (loginSucesso)
            {
                new menu().Show();
                this.Close();
                Conexao.Fechar();
            }
            else
            {
                Conexao.Fechar();
                bunifuSnackbar1.Show(
                   this,
                   "Usuário ou senha incorretos.",
                   Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
            txtUsuarioCliente.Clear();
            txtSenhaCliente.Clear();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenhaCliente.Text.Length > 0)
            {
                txtSenhaCliente.PasswordChar = '*';
            }
            else
            {
                txtSenhaCliente.PasswordChar = '\0';
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(32, 30, 52);
            btnSair.Image = Resources.X;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(27, 25, 47);
            btnSair.Image = Resources.XCinza;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(32, 30, 52);
            btnMinimizar.Image = Resources.Line;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(27, 25, 47);
            btnMinimizar.Image = Resources.LineCinza;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            bunifuPages2.Transition.SlideCoeff = new PointF(1, 0);
            bunifuPages2.SetPage(1);
            login form = this;
            form.AcceptButton = btnEntrarFunc;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            bunifuPages2.Transition.SlideCoeff = new PointF(-1, 0);
            bunifuPages2.SetPage(0);
            login form = this;
            form.AcceptButton = btnEntrarCliente;
        }
    }
}
