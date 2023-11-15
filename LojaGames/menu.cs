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

namespace LojaGames
{

    public partial class menu : Form
    {
        byte[] imagem;
        public menu()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(4);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(3);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            
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
            bunifuButton1.LeftIcon.Image = ButtonController.PegarImagem();
            bunifuButton1.Refresh();
            bunifuButton1.Text = ButtonController.PegarTexto();
        }
    }
}