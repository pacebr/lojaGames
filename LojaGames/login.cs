using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using senac_biblioteca.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LojaGames
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            bool loginSucesso = FuncionarioController.VerificarCredenciais(usuario, senha);

            if (loginSucesso)
            {
                this.Visible = false;
                new menu().ShowDialog();
                this.Visible = true;
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
        }
        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtSenha.Text.Length > 0)
            {
                txtSenha.PasswordChar = '*';
            }
            else
            {
                txtSenha.PasswordChar = '\0';
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               btnEntrar_Click(sender, e);
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnEntrar_Click(sender, e);
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
    }
}
