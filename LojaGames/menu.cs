using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.IO;
using senac_biblioteca.Controllers;
using System.Data.SqlClient;
using LojaGames.Properties;

namespace LojaGames
{

    public partial class menu : Form
    {
        byte[] imagem;
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            btnCasa.Image = Resources.Home_Page_Active;
        }

        private void btnCasa_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(0);
            btnCasa.Image = Resources.Home_Page_Active;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(1);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel_Active;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnJogos_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(2);
            btnCasa.Image = Resources.Home_Page;
            btnJogos.Image = Resources.Game_Controller_Active;
            btnDashboard.Image = Resources.Control_Panel1;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(3);
            pgAdd.SetPage(0);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New_Active;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(4);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash_Active;
            btnConfiguracao.Image = Resources.Wrench;
        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(5);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
            btnConfiguracao.Image = Resources.Wrench_Active;
        }

        private void EscolherImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pcbEscolher.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string texto = txtNomeJogo.Text;
            FuncionarioController.Enviar(imagem, texto);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnJogo1.LeftIcon.Image = ButtonController.PegarImagem(1);
            btnJogo1.Refresh();
            btnJogo1.Text = ButtonController.PegarTexto(1);
            btnJogo2.LeftIcon.Image = ButtonController.PegarImagem(2);
            btnJogo2.Refresh();
            btnJogo2.Text = ButtonController.PegarTexto(2);
            btnJogo3.LeftIcon.Image = ButtonController.PegarImagem(3);
            btnJogo3.Refresh();
            btnJogo3.Text = ButtonController.PegarTexto(3);
            btnJogo4.LeftIcon.Image = ButtonController.PegarImagem(2);
            btnJogo4.Refresh();
            btnJogo4.Text = ButtonController.PegarTexto(2);
            btnJogo5.LeftIcon.Image = ButtonController.PegarImagem(1);
            btnJogo5.Refresh();
            btnJogo5.Text = ButtonController.PegarTexto(1);
        }

        private void btnJogo1_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(0);
        }

        private void btnJogo2_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(1);
        }

        private void btnJogo3_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(2);
        }

        private void btnJogo4_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(3);
        }

        private void btnJogo5_Click(object sender, EventArgs e)
        {
            pgJogos.SetPage(4);
        }

        private void jogo1_Enter(object sender, EventArgs e)
        {
            jogo1.BackgroundImage = ButtonController.PegarImagemJogo(1);
            jogo1.Refresh();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(1);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(2);
        }
    }
}