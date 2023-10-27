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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblRegistrar_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblRegistrar_Click(object sender, EventArgs e)
        {
            lblRegistrar.BackColor = Color.Purple;
            registerForm formregister = new registerForm();
            formregister.ShowDialog();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtBoxUsuario.Text;
            string senha = txtBoxSenha.Text;

            bool loginSucesso = dataAcess.VerificarCredenciais(usuario, senha);

            if (loginSucesso)
            {
                menuForm formmenu = new menuForm();
                formmenu.ShowDialog();
                dataAcess.FecharConexao();
            }
            else
            {
                dataAcess.FecharConexao();
                MessageBox.Show("Falha no login. Usuário ou senha incorretos. Tente novamente.");
            }
        }


    }
}
