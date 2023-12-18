using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using LojaGames.Properties;
using Utilities.BunifuTextBox.Transitions;

namespace LojaGames
{
    public partial class login : Form
    {
        byte[] imagem;
        bool fotoAdd;
        bool fotoAdded;
        string lgenero = "masculino";
        bool limiteUsuario = true;

        public login()
        {
            InitializeComponent();
            txtUsuarioCliente.Select();
            pictureBox3.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            pictureBox2.Parent = pictureBox4;
            label6.Parent = pictureBox4;
        }

        private void btnEntrarCliente_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioCliente.Text;
            string senha = txtSenhaCliente.Text;

            bool loginSucesso = ControleCliente.VerificarCredenciais(usuario, senha);
            UsuarioLogado.usuario = "";

            if (loginSucesso)
            {
                UsuarioLogado.efuncionario = false;
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
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error
                );
            }
            Utilidades.limparCampos(this);
        }

        private void btnEntrarFunc_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioFunc.Text;
            string senha = txtSenhaFunc.Text;
            

            bool loginSucesso = ControleFuncionario.VerificarCredenciais(usuario, senha);
            UsuarioLogado.usuario = usuario;

            if (loginSucesso)
            {
                UsuarioLogado.efuncionario = true;
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
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error
                );
            }
            Utilidades.limparCampos(this);
            voltarImagemCadastro();
        }

        void voltarImagemCadastro()
        {
            pcbImagemCadastro.Image = Resources.Add_Imagem;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            tglbtnMostrarSenhaCli_CheckedChanged(
                sender,
                e as Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs
            );
        }

        private void txtSenhaFunc_TextChanged(object sender, EventArgs e)
        {
            tglbtnMostrarSenhaFunc_CheckedChanged(
                sender,
                e as Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs
            );
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
            Utilidades.limparCampos(this);
            voltarImagemCadastro();
            voltarTextoDrop();
        }

        private void voltarTextoDrop()
        {
            dropGenero.Text = "Selecione";
            dropIdade.Text = "Idade";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            fotoAdded = false;
            bunifuPages1.SetPage(0);
            Utilidades.limparCampos(this);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            Utilidades.limparCampos(this);
            login form = this;
            form.AcceptButton = btnEntrarFunc;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            bunifuPages2.Transition.SlideCoeff = new PointF(-1, 0);
            bunifuPages2.SetPage(0);
            Utilidades.limparCampos(this);
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

                fotoAdded = true;
            }
        }
        private void AtualizarImagemCadastro()
        {
            if (fotoAdded == true)
            {
                return;
            }

            if(fotoAdd == true)
            {
                pcbImagemCadastro.Image = Resources.Add_Imagem;
            }

            if(fotoAdd == false)
            {
                pcbImagemCadastro.Image = Resources.Add_Imagem_Cinza;
            }
        }

        private void pcbImagemCadastro_MouseEnter(object sender, EventArgs e)
        {
            fotoAdd = false;
            AtualizarImagemCadastro();
        }

        private void pcbImagemCadastro_MouseLeave(object sender, EventArgs e)
        {
            fotoAdd = true;
            AtualizarImagemCadastro();
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

            ControleCliente.AddCliente(nome, sobrenome, usuario, senha, idade, genero, CPF, telefone, endereco, imagem);
            Utilidades.limparCampos(this, pcbImagemCadastro);
            voltarTextoDrop();
        }

        private void rdbtnMasculino_CheckedChanged2(
            object sender,
            Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e
        )
        {
            if (rdbtnMasculino.Checked)
            {
                lgenero = "Masculino";
            }
        }

        private void rdbtnFeminino_CheckedChanged2(
            object sender,
            Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e
        )
        {
            if (rdbtnFeminino.Checked)
            {
                lgenero = "Feminino";
            }
        }

        private void rdbtnOutro_CheckedChanged2(
            object sender,
            Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e
        )
        {
            if (rdbtnOutro.Checked)
            {
                dropGenero.Visible = true;
                if (dropGenero.SelectedIndex != -1)
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

        private void LimiteCaracteres(KeyPressEventArgs e, int limite)
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
                bunifuSnackbar1.Show(
                    this,
                    "Máximo de caracteres atingido.",
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning
                );
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

        private void tglbtnMostrarSenhaCli_CheckedChanged(
            object sender,
            Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e
        )
        {
            if (txtSenhaCliente.Text.Length > 0)
            {
                if (tglbtnMostrarSenhaCli.Checked)
                    txtSenhaCliente.PasswordChar = '\0';
                if (!tglbtnMostrarSenhaCli.Checked)
                    txtSenhaCliente.PasswordChar = '*';
            }
            if (txtSenhaCliente.Text.Length == 0 && !tglbtnMostrarSenhaCli.Checked)
            {
                txtSenhaCliente.PasswordChar = '\0';
            }
        }

        private void tglbtnMostrarSenhaFunc_CheckedChanged(
            object sender,
            Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e
        )
        {
            if (txtSenhaFunc.Text.Length > 0)
            {
                if (tglbtnMostrarSenhaFunc.Checked)
                    txtSenhaFunc.PasswordChar = '\0';
                if (!tglbtnMostrarSenhaFunc.Checked)
                    txtSenhaFunc.PasswordChar = '*';
            }
            if (txtSenhaFunc.Text.Length == 0 && !tglbtnMostrarSenhaFunc.Checked)
            {
                txtSenhaFunc.PasswordChar = '\0';
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            AtualizarImagemCadastro();
        }
    }
}