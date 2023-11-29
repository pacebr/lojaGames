using System;
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
using System.Media;

namespace LojaGames
{
    public partial class login : Form
    {
        byte[] imagem;
        bool fotoAdd;
        string lgenero = "masculino";
        bool limiteUsuario = true;
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
            Utilidades.limparCampos(this);
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
            Utilidades.limparCampos(this);
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
            Utilidades.limparCampos(this);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
            Utilidades.limparCampos(this);
        }

        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(32, 30, 52);
            btnSair.Image = Resources.X;
        }

        private void btnSair2_MouseEnter(object sender, EventArgs e)
        {
            btnSair2.BackColor = Color.FromArgb(32, 30, 52);
            btnSair2.Image = Resources.X;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(27, 25, 47);
            btnSair.Image = Resources.XCinza;
        }
        private void btnSair2_MouseLeave(object sender, EventArgs e)
        {
            btnSair2.BackColor = Color.FromArgb(27, 25, 47);
            btnSair2.Image = Resources.XCinza;
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
        private void btnMinimizar2_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar2.BackColor = Color.FromArgb(32, 30, 52);
            btnMinimizar2.Image = Resources.Line;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(27, 25, 47);
            btnMinimizar.Image = Resources.LineCinza;
        }
        private void btnMinimizar2_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar2.BackColor = Color.FromArgb(27, 25, 47);
            btnMinimizar2.Image = Resources.LineCinza;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimizar2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSair2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void pcbImagemCadastro_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pcbImagemCadastro.Image = Image.FromFile(caminhoArquivo);

                fotoAdd = true;
            }
        }

        private void pcbImagemCadastro_MouseEnter(object sender, EventArgs e)
        {
            if (fotoAdd)
                return;
            pcbImagemCadastro.Image = Resources.Add_Imagem_Cinza;
        }

        private void pcbImagemCadastro_MouseLeave(object sender, EventArgs e)
        {
            if (fotoAdd)
                return;
            pcbImagemCadastro.Image = Resources.Add_Imagem;
        }

        private void login_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'exodusDbDataSet.dados'. Você pode movê-la ou removê-la conforme necessário.
            this.dadosTableAdapter.Fill(this.exodusDbDataSet.dados);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {


            string nome = txtNome.Text;
            string sobrenome = txtSobrenome.Text;
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            string idade = dropIdade.Text;
            string genero = lgenero;
            string CPF = txtCPF.Text;
            string telefone = txtTelefone.Text;
            string endereco = txtEndereco.Text;


            //ControleCliente.AddCliente(nome, sobrenome, usuario, senha, idade, genero, CPF, telefone, endereco, imagem);
            Utilidades.limparCampos(this);

        }

        private void rdbtnMasculino_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if(rdbtnMasculino.Checked)
            {
                lgenero = "Masculino";
            }
        }

        private void rdbtnFeminino_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (rdbtnFeminino.Checked)
            {
                lgenero = "Feminino";
            }
        }

        private void rdbtnOutro_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (rdbtnOutro.Checked)
            {
                dropGenero.Visible = true;
                if (dropGenero.SelectedIndex != -1 )
                    lgenero = dropGenero.SelectedValue.ToString();
            }
            else
            {
                dropGenero.Visible = false;
            }
        }
        private void dropGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropGenero.SelectedIndex != -1)
            {
                lgenero = dropGenero.SelectedValue.ToString();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {           
            LimiteCaracteres(e, 10);
        }
        private void LimiteCaracteres (KeyPressEventArgs e, int limite)
        {
            if (e.KeyChar == '\b')
            {
                limiteUsuario = true;
                return;
            }
            if (!limiteUsuario)
                return;
            if (txtUsuario.Text.Length >= limite)
            {
                limiteUsuario = false;
                bunifuSnackbar1.Show(this, "Máximo de caracteres atingido.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimiteCaracteres(e, 11);
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimiteCaracteres(e, 11);
        }
    }
}