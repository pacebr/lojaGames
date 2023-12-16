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
        byte[] alterarImagem;
        byte[] alterarIcone;
        byte[] alterarCarousel;
        int pcbCriadas = 0;

        public menu()
        {
            InitializeComponent();
            pcbJogoCarousel1.Controls.Add(panelJogo1);
            pcbJogoCarousel2.Controls.Add(panelJogo2);
            pcbJogoCarousel3.Controls.Add(panelJogo3);
            pcbJogoCarousel4.Controls.Add(panelJogo4);
            pcbJogoCarousel5.Controls.Add(panelJogo5);

        }

        private Timer timer = new Timer();

        private int currentButtonIndex = 0;

        private void CycleButtons()
        {
            int nextButtonIndex = (currentButtonIndex + 1) % 5;
            pgJogos.SetPage(nextButtonIndex);
            currentButtonIndex = nextButtonIndex;
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
            float? desconto = float.TryParse(txtDesconto.Text, out float result) ? result : (float?)null;

            DadosJogo.EnviarDadosJogo(nome, imagem, descricao, icone, carousel, trailer, preco, genero, desconto, this);
            Utilidades.limparCampos(this, pcbImagemJogo, pcbIcone, pcbCarousel);
            dropGenero.ForeColor = Color.Gray;

        }
        private void tabPage3_Leave(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbImagemJogo, pcbIcone, pcbCarousel);
        }

        private void dropGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropGenero.ForeColor = Color.White;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();

            DataTable dataTable = DadosJogo.PopularDGV();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < 5 && i < dataTable.Rows.Count; i++)
                {
                    BunifuButton btnJogo = Controls.Find($"btnJogo{i + 1}", true).FirstOrDefault() as BunifuButton;
                    PictureBox pcbJogoCarousel = Controls.Find($"pcbJogoCarousel{i + 1}", true).FirstOrDefault() as PictureBox;

                    if (btnJogo != null && pcbJogoCarousel != null)
                    {
                        DataRow row = dataTable.Rows[i];
                        btnJogo.LeftIcon.Image = DadosJogo.PegarIcone(Convert.ToInt32(row["id"]));
                        pcbJogoCarousel.Image = DadosJogo.PegarImagemCarrousel(Convert.ToInt32(row["id"]));
                        string lalala = row["jogo"].ToString();
                        btnJogo.Text = QuebraLinha(lalala, 3);
                        
                    }
                }
            }
        }

        private void tabPage1_Leave(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
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
            panel1.Controls.Clear();

            int posX = 5;
            int posY = 6;
            int numeroImagens = DadosJogo.ObterNumeroImagens();
            pcbCriadas = 0;

            for (int i = 1; i <= numeroImagens; i++)
            {
                while (DadosJogo.PegarImagemGrande(i) == null)
                {
                    i++;
                    numeroImagens++;
                }
                PictureBox pictureBox = new PictureBox()
                {
                    Image = DadosJogo.PegarImagemGrande(i),
                    Size = new Size(290, 290),
                    Location = new Point(posX, posY),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = i,
                    Cursor = Cursors.Hand

                };
                pcbCriadas++;
                pictureBox.MouseClick += pictureBox_Click;
                panel1.Controls.Add(pictureBox);

                posX += 298;
                if (pcbCriadas % 4 == 0)
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

                AbrirDetalhesDoJogo(i);
            }
        }

        private void AbrirDetalhesDoJogo(int idDoJogo)
        {
            pgMenu.SetPage(Jogos);

            string textoBase = DadosJogo.PegarDescricao(idDoJogo);
            string textoPronto = QuebraLinha(textoBase, 10);
            float desconto = float.Parse(DadosJogo.PegarDesconto(idDoJogo));

            lblNomeJogo.Text = DadosJogo.PegarJogo(idDoJogo);
            lblDescricao.Text = textoPronto;
            lblPreco.Text = Convert.ToDecimal(DadosJogo.PegarPreco(idDoJogo)).ToString("C2");
            lblGenero.Text = DadosJogo.PegarGenero(idDoJogo);
            lblPromocao.Text = (Convert.ToDecimal(DadosJogo.PegarPreco(idDoJogo)) * (1 - (decimal)desconto / 100)).ToString("C2");
            lblDesconto.Text = $"{desconto:F0}%";


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

        private static string QuebraLinha(string textoOriginal, int i)
        {
            string[] palavras = textoOriginal.Split(' ');

            int contadorPalavras = 0;

            string textoComQuebrasDeLinha = "";

            foreach (string palavra in palavras)
            {
                textoComQuebrasDeLinha += palavra + " ";

                contadorPalavras++;

                if (contadorPalavras % i == 0)
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
                    column.DefaultCellStyle.Format = "C2";

                if (column.Name.Contains("desconto"))
                    column.DefaultCellStyle.Format = "0\\%";
            }
        }

        private void pcbAlterarImagemJogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                alterarImagem = File.ReadAllBytes(caminhoArquivo);

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
                alterarIcone = File.ReadAllBytes(caminhoArquivo);

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
                alterarCarousel = File.ReadAllBytes(caminhoArquivo);

                pcbAlterarCarouselJogo.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void jogosDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAlterarID.Text = jogosDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtAlterarNomeJogo.Text = jogosDGV.SelectedRows[0].Cells[1].Value.ToString();
            pcbAlterarImagemJogo.Image = (Image)new ImageConverter().ConvertFrom(jogosDGV.SelectedRows[0].Cells[2].Value);
            txtAlterarDescricao.Text = jogosDGV.SelectedRows[0].Cells[3].Value.ToString();
            pcbAlterarIconeJogo.Image = (Image)new ImageConverter().ConvertFrom(jogosDGV.SelectedRows[0].Cells[4].Value);
            pcbAlterarCarouselJogo.Image = (Image)new ImageConverter().ConvertFrom(jogosDGV.SelectedRows[0].Cells[5].Value);
            txtAlterarURL.Text = jogosDGV.SelectedRows[0].Cells[6].Value.ToString();
            txtAlterarPreco.Text = jogosDGV.SelectedRows[0].Cells[7].Value.ToString();
            txtAlterarPreco.Text = float.Parse(jogosDGV.SelectedRows[0].Cells[7].Value.ToString()).ToString("N2", CultureInfo.CurrentCulture);
            dropAlterarGenero.Text = jogosDGV.SelectedRows[0].Cells[8].Value.ToString();
            txtAlterarDesconto.Text = $"{(float.TryParse(jogosDGV.SelectedRows[0].Cells[9].Value?.ToString(), out float desconto) ? desconto : 0):F0}%";

        }

        void carregarImagens()
        {          
            using (MemoryStream stream = new MemoryStream())
            {
                pcbAlterarImagemJogo.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                alterarImagem = stream.ToArray();
            }
            using (MemoryStream stream = new MemoryStream())
            {
                pcbAlterarIconeJogo.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                alterarIcone = stream.ToArray();
            }
            using (MemoryStream stream = new MemoryStream())
            {
               pcbAlterarCarouselJogo.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                alterarCarousel = stream.ToArray();
            }
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (txtAlterarID.Text.Length == 0)
            {
                notify.Show(this, "Selecione um jogo antes", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                Utilidades.limparCampos(this, pcbAlterarImagemJogo, pcbAlterarIconeJogo, pcbAlterarCarouselJogo);
                return;
            }

            carregarImagens();

            int ID = int.Parse(txtAlterarID.Text);
            string jogo = txtAlterarNomeJogo.Text;
            byte[] imagem = alterarImagem;
            string descricao = txtAlterarDescricao.Text;
            byte[] icone = alterarIcone;
            byte[] carousel = alterarCarousel;
            string trailer = txtAlterarURL.Text;
            float preco = float.Parse(txtAlterarPreco.Text);
            string genero = dropAlterarGenero.Text;
            float? desconto = null;

            if (!string.IsNullOrEmpty(txtAlterarDesconto.Text))
            {
                float.TryParse(txtAlterarDesconto.Text.TrimEnd('%'), out float tempDesconto);
                desconto = tempDesconto;
            }

            DadosJogo.EditarJogo(ID, jogo, imagem, descricao, icone, carousel, trailer, preco, genero, desconto);
            PopularDataGridView();
            Utilidades.limparCampos(this, pcbAlterarImagemJogo, pcbAlterarIconeJogo, pcbAlterarCarouselJogo);
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


                t.Text = string.Format("{0:#,##0.00}", Double.Parse(w) / 100);
                t.Select(t.Text.Length, 0);
            }
                e.Handled = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbAlterarImagemJogo, pcbAlterarIconeJogo, pcbAlterarCarouselJogo);
            resetarDropDown();
        }
        void resetarDropDown()
        {
            dropAlterarGenero.SelectedIndex = -1;
            dropAlterarGenero.Text = "Genero";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            int id = string.IsNullOrEmpty(txtAlterarID.Text) ? 0 : int.Parse(txtAlterarID.Text);

            DadosJogo.DeletarJogo(id, txtAlterarID);
            PopularDataGridView();
            btnLimpar_Click(sender, e);
        }

        private void tabPage8_Leave(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbAlterarImagemJogo, pcbAlterarIconeJogo, pcbAlterarCarouselJogo);
            resetarDropDown();
        }

        private void btnComprarJogo1_Click(object sender, EventArgs e)
        {
            AbrirDetalhesDoJogo(1);
        }

        private void btnComprarJogo2_Click(object sender, EventArgs e)
        {
            AbrirDetalhesDoJogo(2);
        }

        private void btnComprarJogo3_Click(object sender, EventArgs e)
        {
            AbrirDetalhesDoJogo(3);
        }

        private void btnComprarJogo4_Click(object sender, EventArgs e)
        {
            AbrirDetalhesDoJogo(4);
        }

        private void btnComprarJogo5_Click(object sender, EventArgs e)
        {
            AbrirDetalhesDoJogo(5);
        }

        private void rdbtnDescontoSim_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if(rdbtnDescontoSim.Checked)
            {
                txtDesconto.Visible = true;
            }
            if (!rdbtnDescontoSim.Checked)
            {
                txtDesconto.Visible=false;
            }
        }

        private void txtAlterarDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox)sender;
                string w = Regex.Replace(t.Text, "[^0-9]", string.Empty);

                if (e.KeyChar.Equals((char)Keys.Back) && w.Length > 0)
                {
                    w = w.Substring(0, w.Length - 1);
                }

                if (char.IsDigit(e.KeyChar))
                {
                    w += e.KeyChar;
                }

                t.Text = $"{w}%";
                t.Select(t.Text.Length - 1, 0);
            }

            e.Handled = true;
        }



    }
}