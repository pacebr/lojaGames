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

namespace LojaGames
{

    public partial class menu : Form
    {
        byte[] imagem;
        public menu()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {

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

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuButton1.LeftIcon.Image = ImageControl.Imgcontrol();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg|*.jpg;*.png;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pictureBox2.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
  
      
            FuncionarioController.AddCliente(imagem);
        }
    }
}
