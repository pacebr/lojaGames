using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using LojaGames.Properties;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;

namespace LojaGames
{
    public partial class menu : Form
    {
        byte[] imagem;
        byte[] icone;
        byte[] carousel;
        int idJogosDGV;

        public menu()
        {
            InitializeComponent();
            pcbJogoCarousel1.Controls.Add(panelJogo1);
            pcbJogoCarousel2.Controls.Add(panelJogo2);
            pcbJogoCarousel3.Controls.Add(panelJogo3);
            pcbJogoCarousel4.Controls.Add(panelJogo4);
            pcbJogoCarousel5.Controls.Add(panelJogo5);
        }

        private void CycleButtons()
        {
            int currentButtonIndex = pgJogos.SelectedIndex;
            int nextButtonIndex = (currentButtonIndex + 1) % 5;
            pgJogos.SetPage(nextButtonIndex);
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

        private void btnJogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pcbImagemJogo.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void btnEnviarjogo_Click(object sender, EventArgs e)
        {
            string nome = txtNomeJogo.Text;
            string descricao = txtDescricao.Text;
            string trailer = txtTrailer.Text;
            string preco = txtPreco.Text;
            string genero = dropGenero.Text;

            DadosJogo.EnviarDadosJogo(nome, imagem, descricao, icone, carousel, trailer, preco, genero, this);
            dropGenero.ForeColor = Color.Gray;
        }
        private void dropGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropGenero.ForeColor = Color.White;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnJogo1.LeftIcon.Image = DadosJogo.PegarIcone(1);
            pcbJogoCarousel1.Image = DadosJogo.PegarImagemCarrousel(1);
            btnJogo1.Refresh();
            btnJogo1.Text = DadosJogo.PegarJogo(1);
            btnJogo2.LeftIcon.Image = DadosJogo.PegarIcone(2);
            pcbJogoCarousel2.Image = DadosJogo.PegarImagemCarrousel(2);
            btnJogo2.Refresh();
            btnJogo2.Text = DadosJogo.PegarJogo(2);
            btnJogo3.LeftIcon.Image = DadosJogo.PegarIcone(3);
            pcbJogoCarousel3.Image = DadosJogo.PegarImagemCarrousel(3);
            btnJogo3.Refresh();
            btnJogo3.Text = DadosJogo.PegarJogo(3);
            btnJogo4.LeftIcon.Image = DadosJogo.PegarIcone(4);
            pcbJogoCarousel4.Image = DadosJogo.PegarImagemCarrousel(4);
            btnJogo4.Refresh();
            btnJogo4.Text = DadosJogo.PegarJogo(4);
            btnJogo5.LeftIcon.Image = DadosJogo.PegarIcone(5);
            pcbJogoCarousel5.Image = DadosJogo.PegarImagemCarrousel(5);
            btnJogo5.Refresh();
            btnJogo5.Text = DadosJogo.PegarJogo(5);
            CycleButtons();
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
            jogo1.BackgroundImage = DadosJogo.PegarImagemCarrousel(1);
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

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            criarPcb();
        }

        private void criarPcb()
        {
            int posX = 5;
            int posY = 6;
            int numeroImagens = DadosJogo.ObterNumeroImagens();

            for (int i = 1; i <= numeroImagens; i++)
            {
                PictureBox pictureBox = new PictureBox()
                {
                    Image = DadosJogo.PegarImagemGrande(i),
                    Size = new Size(290, 290),
                    Location = new Point(posX, posY),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = i,
                    Cursor = Cursors.Hand

                };
                pictureBox.MouseClick += pictureBox_Click;
                panel1.Controls.Add(pictureBox);

                posX += 298;
                if (i % 4 == 0)
                {
                    posX = 5;
                    posY += 300;
                }
            }
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox != null && int.TryParse(clickedPictureBox.Tag.ToString(), out int i))
            {
                if (i <= 0)
                {
                    notify.Show(this, "Jogo Inexistente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }

                pgMenu.SetPage(Jogos);
                lblNomeJogo.Text = DadosJogo.PegarJogo(i);
                string textoBase = DadosJogo.PegarDescricao(i);
                string textoPronto = QuebraLinha(textoBase);
                lblDescricao.Text = textoPronto;

                int idDoJogo = i;

                string linkDoVideo = DadosJogo.PegarTrailer(idDoJogo);

                string linkIncorporado = DadosJogo.ObterLinkIncorporado(linkDoVideo);

                if (!string.IsNullOrEmpty(linkIncorporado))
                {
                    if (pnTrailer.Controls.Count > 0 && pnTrailer.Controls[0] is WebBrowser)
                    {
                        pnTrailer.Controls[0].Dispose();
                    }

                    WebBrowser webBrowser = new WebBrowser();
                    webBrowser.Dock = DockStyle.Fill;
                    webBrowser.ScriptErrorsSuppressed = true;
                    webBrowser.ScrollBarsEnabled = false;

                    string html = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
                    <style>
                        body, html, iframe {{ margin: 0; padding: 0; width: 100%; height: 100%; border: 0; overflow: hidden; }}
                        iframe {{ border: none; }}
                    </style>
                </head>
                <body>
                    <iframe src=""{linkIncorporado}"" frameborder=""0"" allowfullscreen></iframe>
                </body>
                </html>";

                    webBrowser.DocumentText = html;

                    pnTrailer.Controls.Add(webBrowser);
                }
                else
                {
                    notify.Show(this, "O link do vídeo não é válido.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
            }
        }

        private static string QuebraLinha(string textoOriginal)
        {
            string[] palavras = textoOriginal.Split(' ');

            int contadorPalavras = 0;

            string textoComQuebrasDeLinha = "";

            foreach (string palavra in palavras)
            {
                textoComQuebrasDeLinha += palavra + " ";

                contadorPalavras++;

                if (contadorPalavras % 10 == 0)
                {
                    textoComQuebrasDeLinha += "\n";
                }
            }

            return textoComQuebrasDeLinha;
        }

        private void btnIcone_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter =
                    "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                    icone = File.ReadAllBytes(caminhoArquivo);

                    pcbIcone.Image = Image.FromFile(caminhoArquivo);
                }
            }
        }

        private void btnCarousel_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter =
                    "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                    carousel = File.ReadAllBytes(caminhoArquivo);

                    pcbCarousel.Image = Image.FromFile(caminhoArquivo);
                }
            }
        }

        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(152, 145, 202);
            btnSair.Image = Resources.Exit;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(147, 140, 197);
            btnSair.Image = Resources.ExitCinza;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
            new login().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CycleButtons();
        }
        private void RemoverControlesDoPanel(Panel panel)
        {
            foreach (Control controle in panel.Controls)
            {
                controle.Dispose();
            }

            panel.Controls.Clear();
        }

        private void pcbMostrarJogo_Click(object sender, EventArgs e)
        {
            PictureBox pcbMostrar = panel2.Controls.OfType<PictureBox>().FirstOrDefault();

            if (pcbMostrarIcone.Image != Resources.fechar_o_olho__1_ || pcbMostrarCarousel.Image != Resources.fechar_o_olho__1_)
            {
                RemoverControlesDoPanel(panel2);
                pcbMostrarIcone.Image = Resources.fechar_o_olho__1_;
                pcbMostrarCarousel.Image = Resources.fechar_o_olho__1_;
            }
            if (pcbMostrar != null)
            {
                pcbMostrarJogo.Image = Resources.fechar_o_olho__1_;
                lblMostrar.Text = "";
                panel2.Controls.Remove(pcbMostrar);
                pcbMostrar.Dispose();
            }
            if (pcbMostrar == null)
            {
                pcbMostrarJogo.Image = Resources.olho;
                lblMostrar.Text = "Imagem Jogo";
                lblMostrar.Location = new Point(607, 309);

                PictureBox PictureBox = new PictureBox()
                {
                    Image = pcbImagemJogo.Image,
                    Size = new Size(290, 290),
                    Location = new Point(0, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                panel2.Controls.Add(PictureBox);
            }
        }

        private void pcbMostrarIcone_Click(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton btnMostrar = panel2.Controls.OfType<Bunifu.UI.WinForms.BunifuButton.BunifuButton>().FirstOrDefault();

            if (pcbMostrarJogo.Image != Resources.fechar_o_olho__1_ || pcbMostrarCarousel.Image != Resources.fechar_o_olho__1_)
            {
                RemoverControlesDoPanel(panel2);
                pcbMostrarJogo.Image = Resources.fechar_o_olho__1_;
                pcbMostrarCarousel.Image = Resources.fechar_o_olho__1_;
            }
            if (btnMostrar != null)
            {
                pcbMostrarIcone.Image = Resources.fechar_o_olho__1_;
                lblMostrar.Text = "";
                panel2.Controls.Remove(btnMostrar);
                btnMostrar.Dispose();
            }
            if (btnMostrar == null)
            {
                pcbMostrarIcone.Image = Resources.olho;
                lblMostrar.Text = "Botão Carousel";
                lblMostrar.Location = new Point(600, 309);
                Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton = new BunifuButton()
                {
                    Size = new Size(253, 97),
                    Text = "Nome do Jogo Aqui",
                    TextAlign = ContentAlignment.MiddleRight,
                    Location = new Point(0, -20),
                    IdleBorderRadius = 15
                };
                bunifuButton.IdleFillColor = Color.FromArgb(37, 35, 57);
                bunifuButton.IdleBorderColor = Color.Transparent;
                bunifuButton.LeftIcon.Image = pcbIcone.Image;
                bunifuButton.Refresh();
                panel2.Controls.Add(bunifuButton);
            }
        }

        private void pcbMostrarCarousel_Click(object sender, EventArgs e)
        {
            PictureBox pcbMostrar = panel2.Controls.OfType<PictureBox>().FirstOrDefault();

            if (pcbMostrarJogo.Image != Resources.fechar_o_olho__1_ || pcbMostrarIcone.Image != Resources.fechar_o_olho__1_)
            {
                RemoverControlesDoPanel(panel2);
                pcbMostrarJogo.Image = Resources.fechar_o_olho__1_;
                pcbMostrarIcone.Image = Resources.fechar_o_olho__1_;
            }
            if (pcbMostrar != null)
            {
                pcbMostrarCarousel.Image = Resources.fechar_o_olho__1_;
                lblMostrar.Text = "";
                panel2.Controls.Remove(pcbMostrar);
                pcbMostrar.Dispose();
            }
            if (pcbMostrar == null)
            {
                pcbMostrarCarousel.Image = Resources.olho;
                lblMostrar.Text = "Imagem Carrousel";
                lblMostrar.Location = new Point(591, 309);

                PictureBox PictureBox = new PictureBox()
                {
                    Image = pcbCarousel.Image,
                    Size = new Size(290, 290),
                    Location = new Point(0, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                panel2.Controls.Add(PictureBox);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            notify.Show(this, "Procure o atendente mais proximo.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information);
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox)sender;
                string w = Regex.Replace(t.Text, "[^0-9]", string.Empty);
                if (w == string.Empty) w = "00";

                if (e.KeyChar.Equals((char)Keys.Back))
                    w = w.Substring(0, w.Length - 1);
                else
                    w += e.KeyChar;

                // Converta o valor para double e, em seguida, formate-o como uma moeda sem o símbolo
                double preco = Double.Parse(w) / 100;
                t.Text = preco.ToString("N2", CultureInfo.CurrentCulture);
                t.Select(t.Text.Length, 0);
            }
            e.Handled = true;
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {
            PopularDataGridView();
        }

        private void PopularDataGridView()
        {
            DataTable dataTable = DadosJogo.PopularDGV();

            if (dataTable != null)
            {
                jogosDGV.DataSource = dataTable;
            }
            else
            {
                notify.Show(this, "Erro ao carregar dados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
        }
        private void jogosDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in jogosDGV.Columns)
            {
                if (column.Name.Contains("preco"))
                {
                    column.DefaultCellStyle.Format = "C2";
                }
            }
        }

        private void pcbAlterarImagemJogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pcbAlterarImagemJogo.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void pcbAlterarIconeJogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pcbAlterarIconeJogo.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void pcbAlterarCarouselJogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                imagem = File.ReadAllBytes(caminhoArquivo);

                pcbAlterarCarouselJogo.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void jogosDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idJogosDGV = int.Parse(jogosDGV.SelectedRows[0].Cells[0].Value.ToString());
            txtAlterarNomeJogo.Text = jogosDGV.SelectedRows[0].Cells[1].Value.ToString();
            pcbAlterarImagemJogo.Image = (Image)new ImageConverter().ConvertFrom(jogosDGV.SelectedRows[0].Cells[2].Value);
            txtAlterarDescricao.Text = jogosDGV.SelectedRows[0].Cells[3].Value.ToString();
            pcbAlterarIconeJogo.Image = (Image)new ImageConverter().ConvertFrom(jogosDGV.SelectedRows[0].Cells[4].Value);
            pcbAlterarCarouselJogo.Image = (Image)new ImageConverter().ConvertFrom(jogosDGV.SelectedRows[0].Cells[5].Value);
            txtAlterarURL.Text = jogosDGV.SelectedRows[0].Cells[6].Value.ToString();
            txtAlterarPreco.Text = jogosDGV.SelectedRows[0].Cells[7].Value.ToString();
            txtAlterarPreco.Text = ((decimal)jogosDGV.SelectedRows[0].Cells[7].Value).ToString("C2", CultureInfo.CurrentCulture);
            dropGenero.Text = jogosDGV.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            //DadosJogo.EditarJogo(idJogosDGV,)
        }

        private void txtAlterarPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox)sender;
                string w = Regex.Replace(t.Text, "[^0-9]", string.Empty);
                if (w == string.Empty) w = "00";

                if (e.KeyChar.Equals((char)Keys.Back))
                    w = w.Substring(0, w.Length - 1);
                else
                    w += e.KeyChar;

                // Converta o valor para double e, em seguida, formate-o como uma moeda sem o símbolo
                double preco = Double.Parse(w) / 100;
                t.Text = preco.ToString("N2", CultureInfo.CurrentCulture);
                t.Select(t.Text.Length, 0);
            }
            e.Handled = true;
        }
    }
}