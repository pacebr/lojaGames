using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaGames
{
    public class CriacaoPcb
    {
        public PictureBox[] CriarPb()
        {
            int numeroImagens = DadosJogo.ObterNumeroImagens();
            PictureBox[] pictureBoxes = new PictureBox[numeroImagens];

            for (int i = 0; i < numeroImagens; i++)
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].Image = DadosJogo.PegarImagemGrande(i);
                pictureBoxes[i].Click += (object sender, EventArgs e) =>
                {
                    MessageBox.Show("ID: " + i);
                };

                return pictureBoxes;
            }
            return null;
        }
    }
}