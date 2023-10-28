using LojaGames.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaGames
{
    public partial class login : Form
    {
        bool isFuncionario = false;
        bool loginSucesso;
        public login()
        {
            InitializeComponent();
            label6.Text = "";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblRegistrar_Click(object sender, EventArgs e)
        {
            registro formregister = new registro();
            formregister.ShowDialog();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtBoxUsuario.Text;
            string senha = txtBoxSenha.Text;

            if (isFuncionario)
                loginSucesso = FuncionarioController.VerificarCredenciais(usuario, senha);
            if (!isFuncionario)
                loginSucesso = ClienteController.VerificarCredenciais(usuario, senha);

            if (loginSucesso)
            {
                LoginConfirmado(usuario, senha);
                return;
            }
            MessageBox.Show("Falha no Login! Usuario e/ou senha incorretos.");

        }

        private void lblRegistrar_MouseEnter(object sender, EventArgs e)
        {
            lblRegistrar.ForeColor = Color.Purple;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lblRegistrar_MouseLeave(object sender, EventArgs e)
        {
            lblRegistrar.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void txtBoxSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void txtBoxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void toggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleButton1.Checked == true)
                IsFuncionario();
            if (toggleButton1.Checked == false)
                IsCliente();
        }
        private void LoginConfirmado(string usuario, string senha)
        {
            if (isFuncionario)
            {
                if (FuncionarioController.VerificarGerencia(usuario))
                {
                    menu formmenu = new menu();
                    formmenu.ShowDialog();
                }
                if (!FuncionarioController.VerificarGerencia(usuario))
                {
                    MessageBox.Show("funcionario buxa");
                }
            }
            if (!isFuncionario)
            {
                MessageBox.Show("É CLIENTE");
            }
        }
        private void IsFuncionario()
        {
            label6.Text = "FUNCIONARIO";
            isFuncionario = true;
        }
        private void IsCliente()
        {
            label6.Text = "";
            isFuncionario = false;
        }
    }
}
