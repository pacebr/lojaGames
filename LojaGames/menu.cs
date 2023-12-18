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
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
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
        byte[] FotoFuncionario;
        byte[] AlterarFotoFuncionario;
        byte[] AlterarFotoCliente;
        int pcbCriadas = 0;

        public menu()
        {
            InitializeComponent();
            LimitarAcessoFuncionarios();
            LimitarAcessoCliente();
            LimitarAcessoExplorar();
            pcbJogoCarousel1.Controls.Add(panelJogo1);
            pcbJogoCarousel2.Controls.Add(panelJogo2);
            pcbJogoCarousel3.Controls.Add(panelJogo3);
            pcbJogoCarousel4.Controls.Add(panelJogo4);
            pcbJogoCarousel5.Controls.Add(panelJogo5);
            pictureBox2.Parent = bunifuPanel2;

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
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(1);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel_Active;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
        }

        private void btnJogos_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(2);
            btnCasa.Image = Resources.Home_Page;
            btnJogos.Image = Resources.Game_Controller_Active;
            btnDashboard.Image = Resources.Control_Panel1;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
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
        }

        private void btnDinheiro_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(4);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash_Active;
        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            pgMenu.SetPage(5);
            btnCasa.Image = Resources.Home_Page;
            btnDashboard.Image = Resources.Control_Panel1;
            btnJogos.Image = Resources.Game_Controller;
            btnAdicionar.Image = Resources.Add_New;
            btnDinheiro.Image = Resources.Cash;
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
            resetarDropDown(dropGenero, "Genero", Color.Gray);

        }
        private void tabPage7_Leave(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbImagemJogo, pcbIcone, pcbCarousel);
            resetarDropDown(dropGenero, "Genero", Color.Gray);
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

            DataTable dataTable = DadosJogo.PopularDGVJogos();

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

        private void btnAdicionarJogo_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(1);
        }

        private void btnGerenciarJogos_Click(object sender, EventArgs e)
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
            UsuarioLogado.explorar = false;
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
            popularJogosDGV();
        }

        private void popularJogosDGV()
        {
            DataTable dataTable = DadosJogo.PopularDGVJogos();

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
            txtAlterarPreco.Text = float.Parse(jogosDGV.SelectedRows[0].Cells[7].Value.ToString()).ToString("N2", CultureInfo.CurrentCulture);
            dropAlterarGenero.Text = jogosDGV.SelectedRows[0].Cells[8].Value.ToString();
            dropAlterarGenero.ForeColor = Color.White;
            txtAlterarDesconto.Text = $"{(float.TryParse(jogosDGV.SelectedRows[0].Cells[9].Value?.ToString(), out float desconto) ? desconto : 0):F0}%";

        }

        void carregarImagensJogo()
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
                resetarDropDown(dropAlterarGenero, "Genero", Color.Gray);
                return;
            }

            carregarImagensJogo();

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
            popularJogosDGV();
            Utilidades.limparCampos(this, pcbAlterarImagemJogo, pcbAlterarIconeJogo, pcbAlterarCarouselJogo);
            resetarDropDown(dropAlterarGenero, "Genero", Color.Gray);
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
            resetarDropDown(dropAlterarGenero, "Genero", Color.Gray );
        }
        void resetarDropDown(Bunifu.UI.WinForms.BunifuDropdown dropdown, string texto, Color color)
        {
            dropdown.SelectedIndex = -1;
            dropdown.Text = texto;
            dropdown.ForeColor = color;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            int id = string.IsNullOrEmpty(txtAlterarID.Text) ? 0 : int.Parse(txtAlterarID.Text);

            DadosJogo.DeletarJogo(id, txtAlterarID);
            popularJogosDGV();
            btnLimpar_Click(sender, e);
        }

        private void tabPage8_Leave(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbAlterarImagemJogo, pcbAlterarIconeJogo, pcbAlterarCarouselJogo);
            resetarDropDown(dropAlterarGenero, "Genero", Color.Gray);
        }
        private void dropAlterarGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropAlterarGenero.ForeColor = Color.White;
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

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dropNomeJogoVenda.Text.Length == 0 || dropQuantidadeVenda.SelectedIndex == -1 ||
               txtValorJogoVenda.Text.Length == 0 || txtClienteID.Text.Length == 0 || txtFuncionarioID.Text.Length == 0)
            {
                notify.Show(this, "Complete todos os campos.", BunifuSnackbar.MessageTypes.Warning);
                return;
            }

            if(!string.IsNullOrEmpty(dropQuantidadeVenda.Text))
            {
                string jogo = dropNomeJogoVenda.Text;
                int quantidade = int.Parse(dropQuantidadeVenda.Text);
                float valorJogo = float.Parse(txtValorJogoVenda.Text);
                float valor = quantidade * valorJogo;
                int idCliente = int.Parse(txtClienteID.Text);
                int idFuncionario = int.Parse(txtFuncionarioID.Text);

                if (!ControleFuncionario.VerificarExistencia(idFuncionario) ||
                   !ControleCliente.VerificarExistencia(idCliente))
                {
                    notify.Show(this, "Funcionário ou cliente inexistente.", BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (!DadosJogo.VerificarJogo(jogo))
                {
                    notify.Show(this, "Jogo inválido", BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                bool addVendas = ControleVendas.AddVendas(jogo, quantidade, valor, idCliente, idFuncionario);

                if (addVendas)
                    notify.Show(this, "Venda realizada com sucesso!", BunifuSnackbar.MessageTypes.Success);

                if (!addVendas)
                    notify.Show(this, "Verifique se as informações estão corretas.", BunifuSnackbar.MessageTypes.Error);
            }
            btnLimparVenda_Click(sender, e);
            popularVendasDGV();
        }

        private void btnLimparVenda_Click(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbJogoVenda, pcbFotoCliente, pcbFotoFuncionario);
            resetarDropDown(dropQuantidadeVenda, "Quantidade", Color.Gray);
            resetarDropDown(dropNomeJogoVenda, "Nome do jogo", Color.Gray);
        }

        private void tabPage4_Leave(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbJogoVenda, pcbFotoCliente, pcbFotoFuncionario);
            resetarDropDown(dropQuantidadeVenda, "Quantidade", Color.Gray);
            resetarDropDown(dropQuantidadeVenda, "Nome do jogo", Color.Gray);
        }

        private void txtFuncionarioID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFuncionarioID.Text))
            {
                txtNomeFuncionario.Text = string.Empty;
                pcbFotoFuncionario.Visible = false;
                return;
            }

            if (int.TryParse(txtFuncionarioID.Text, out int idFuncionario))
            {
                txtNomeFuncionario.Text = ControleFuncionario.ObterNomeFuncionario(idFuncionario) ?? string.Empty;
            }

            int idValido = int.Parse(txtFuncionarioID.Text);
            bool idVerificado = ControleFuncionario.VerificarExistencia(idValido);

            if (idVerificado)
            {
                Image fotoFuncionario = ControleFuncionario.ObterImagemDoFuncionarioPeloID(idValido);

                if (fotoFuncionario != null)
                {
                    pcbFotoFuncionario.Image = fotoFuncionario;
                    pcbFotoFuncionario.Visible = true;
                }
            }

            if (!idVerificado)
            {
                pcbFotoFuncionario.Visible = false;
                notify.Show(this, "Selecione um ID válido", BunifuSnackbar.MessageTypes.Warning);
            }
        }

        private void txtClienteID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClienteID.Text))
            {
                txtNomeCliente.Text = string.Empty;
                pcbFotoCliente.Visible = false;
                return;
            }

            if (int.TryParse(txtClienteID.Text, out int idCliente))
            {
                txtNomeCliente.Text = ControleCliente.ObterNomeCliente(idCliente) ?? string.Empty;
            }

            int idValido = int.Parse(txtClienteID.Text);
            bool idVerificado = ControleCliente.VerificarExistencia(idValido);

            if (idVerificado)
            {
                Image fotoCliente = ControleCliente.ObterImagemDoClientePeloID(idValido);

                if (fotoCliente != null)
                {
                    pcbFotoCliente.Image = fotoCliente;
                    pcbFotoCliente.Visible = true;
                }
            }

            if (!idVerificado)
            {
                pcbFotoCliente.Visible = false;
                notify.Show(this, "Selecione um ID válido", BunifuSnackbar.MessageTypes.Warning);
            }
        }

        private void PreencherDropdownJogos()
        {
            dropNomeJogoVenda.Items.Clear();

            List<string> nomesJogos = DadosJogo.ObterNomeJogos();

            foreach (string nomeJogo in nomesJogos)
            {
                dropNomeJogoVenda.Items.Add(nomeJogo);
            }

            if (dropNomeJogoVenda.Items.Count > 0)
            {
                dropNomeJogoVenda.SelectedIndex = 0;
            }
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            popularVendasDGV();
            PreencherDropdownJogos();
            btnLimparVenda_Click(sender, e);
        }

        private void dropNomeJogoVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropNomeJogoVenda.SelectedItem != null)
            {
                string nomeJogo = dropNomeJogoVenda.SelectedItem.ToString();

                int idJogo = DadosJogo.ObterIdDoJogoPeloNome(nomeJogo);
                float precoJogo = DadosJogo.ObterPrecoDoJogoPeloNome(nomeJogo);

                float quantidade;
                float precoTotal;
                if (dropQuantidadeVenda.SelectedItem != null && float.TryParse(dropQuantidadeVenda.SelectedItem.ToString(), out quantidade))
                {
                    precoTotal = precoJogo * quantidade;
                }
                else
                {
                    precoTotal = precoJogo;
                }

                Image imagemJogo = DadosJogo.ObterImagemDoJogoPeloNome(nomeJogo);

                txtJogoID.Text = idJogo.ToString();
                txtValorJogoVenda.Text = precoTotal.ToString("N2");
                pcbJogoVenda.Image = imagemJogo;
            }

            dropNomeJogoVenda.ForeColor = Color.White;
        }

        private void vendasDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
             foreach (DataGridViewColumn column in vendasDGV.Columns)
            {
                if (column.Name.Contains("valor"))
                    column.DefaultCellStyle.Format = "C2";

            }
        }
        private void popularVendasDGV()
        {
            DataTable dataTable = ControleVendas.PopularDGVvendas();

            if (dataTable != null)
            {
                vendasDGV.DataSource = dataTable;
            }
            else
            {
                notify.Show(this, "Erro ao carregar dados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
        }

        private void dropQuantidadeVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJogoID.Text) && int.TryParse(txtJogoID.Text, out int id))
            {
                float valorJogo = float.Parse(DadosJogo.PegarPreco(id));
                float quantidade = float.Parse(dropQuantidadeVenda.Text);
                float valortotal = valorJogo * quantidade;

                txtValorJogoVenda.Text = valortotal.ToString("N2");
                dropQuantidadeVenda.ForeColor = Color.White;
            }
            else
            {
                return;
            }
        }

        private void txtClienteID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtFuncionarioID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnAlterarVenda_Click(object sender, EventArgs e)
        {
            if (txtJogoID.Text.Length == 0 || txtFuncionarioID.Text.Length == 0 || txtClienteID.Text.Length == 0)
            {
                notify.Show(this, "Complete todos os Campos Antes", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                Utilidades.limparCampos(this, pcbFotoCliente, pcbFotoFuncionario);
                resetarDropDown(dropNomeJogoVenda, "Nome do jogo", Color.Gray);
                resetarDropDown(dropQuantidadeVenda, "Quantidade", Color.Gray);
                return;
            }

            int ID = int.Parse(txtVendaID.Text);
            string jogo = dropNomeJogoVenda.Text;
            int quantidade = int.Parse(dropQuantidadeVenda.Text);
            float valor = float.Parse(txtValorJogoVenda.Text);
            int clienteID = int.Parse(txtClienteID.Text);
            int funcionarioID = int.Parse(txtFuncionarioID.Text);

            ControleVendas.EditarVendas(ID, jogo, quantidade, valor, clienteID, funcionarioID);
            popularVendasDGV();
            Utilidades.limparCampos(this, pcbFotoCliente, pcbFotoFuncionario, pcbJogoVenda);
            resetarDropDown(dropNomeJogoVenda, "Nome do jogo", Color.Gray);
            resetarDropDown(dropQuantidadeVenda, "Quantidade", Color.Gray);
        }

        private void btnDeletarVenda_Click(object sender, EventArgs e)
        {
            int id = string.IsNullOrEmpty(txtVendaID.Text) ? 0 : int.Parse(txtVendaID.Text);

            ControleVendas.DeleteVendas(id, txtVendaID);
            popularVendasDGV();
            btnLimparVenda_Click(sender, e);
        }

        private void vendasDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVendaID.Text = vendasDGV.SelectedRows[0].Cells[0].Value.ToString();
            dropNomeJogoVenda.Text = vendasDGV.SelectedRows[0].Cells[1].Value.ToString();
            dropQuantidadeVenda.Text = vendasDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtValorJogoVenda.Text = float.Parse(vendasDGV.SelectedRows[0].Cells[3].Value.ToString()).ToString("N2", CultureInfo.CurrentCulture);
            txtClienteID.Text = vendasDGV.SelectedRows[0].Cells[4].Value.ToString();
            txtFuncionarioID.Text = vendasDGV.SelectedRows[0].Cells[5].Value.ToString();

            string nomeJogo = dropNomeJogoVenda.Text;
            int idJogo = DadosJogo.ObterIdDoJogoPeloNome(nomeJogo);
            Image imagemJogo = DadosJogo.ObterImagemDoJogoPeloNome(nomeJogo);


            txtJogoID.Text = idJogo.ToString();
            pcbJogoVenda.Image = imagemJogo;

            dropNomeJogoVenda.ForeColor = Color.White;
            dropQuantidadeVenda.ForeColor = Color.White;
        }

        private void btnAdicionarFuncionario_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(3);
        }

        private void btnGerenciarFuncionario_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(4);
        }

        private void btnGerenciarCliente_Click(object sender, EventArgs e)
        {
            pgAdd.SetPage(5);
        }

        private void btnAddFotoFuncionario_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                FotoFuncionario = File.ReadAllBytes(caminhoArquivo);

                pcbAddFotoFuncionario.Image = Image.FromFile(caminhoArquivo);
            }
        }

        private void btnAddLimpar_Click(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbAddFotoFuncionario);
            resetarDropDown(dropAddGeneroFuncionario, "Genero", Color.Gray);
        }

        private void txtAddCPFfuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnAddFuncionario_Click(object sender, EventArgs e)
        {
            string nome = txtAddNomeFuncionario.Text;
            string sobrenome = txtAddSobrenomeFuncionario.Text;
            string CPF = txtAddCPFfuncionario.Text;
            string genero = dropAddGeneroFuncionario.Text;
            string idade = dropAddIdadeFuncionario.Text;
            string cargo = dropAddCargoFuncionario.Text;
            string usuario = txtAddUsuarioFuncionario.Text;
            string senha = txtAddSenhaFuncionario.Text;
            byte[] foto = FotoFuncionario;


            ControleFuncionario.AdicionarFuncionario(nome, sobrenome, CPF, genero, idade, cargo, usuario, senha, foto);
            Utilidades.limparCampos(this, pcbAddFotoFuncionario);
            resetarDropDown(dropAddGeneroFuncionario, "Genero", Color.Gray);
            resetarDropDown(dropAddIdadeFuncionario, "Idade", Color.Gray);
            resetarDropDown(dropAddCargoFuncionario, "Cargo", Color.Gray);
            popularVendasDGV();
        }

        private void dropAddGeneroFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropAddGeneroFuncionario.ForeColor = Color.White;
        }

        private void dropAddIdadeFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropAddIdadeFuncionario.ForeColor = Color.White;
        }

        private void dropAddCargoFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropAddCargoFuncionario.ForeColor = Color.White;
        }

        private void tabPage9_Leave(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbAddFotoFuncionario);
            resetarDropDown(dropAddGeneroFuncionario, "Genero", Color.Gray);
            resetarDropDown(dropAddIdadeFuncionario, "Idade", Color.Gray);
            resetarDropDown(dropAddCargoFuncionario, "Cargo", Color.Gray);
        }

        private void dropNomeJogoVenda_TextChanged(object sender, EventArgs e)
        {
            if (dropNomeJogoVenda.SelectedItem != null)
            {
                string nomeJogo = dropNomeJogoVenda.SelectedItem.ToString();

                int idJogo = DadosJogo.ObterIdDoJogoPeloNome(nomeJogo);
                float precoJogo = DadosJogo.ObterPrecoDoJogoPeloNome(nomeJogo);
                Image imagemJogo = DadosJogo.ObterImagemDoJogoPeloNome(nomeJogo);


                txtJogoID.Text = idJogo.ToString();
                txtValorJogoVenda.Text = precoJogo.ToString("N2");
                pcbJogoVenda.Image = imagemJogo;
            }

            dropNomeJogoVenda.ForeColor = Color.White;
        }

        private void btnAlterarLimparFuncionario_Click(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbAlterarFotoFuncionario);
            resetarDropDown(dropAlterarGeneroFuncionario, "Genero", Color.Gray);
            resetarDropDown(dropAlterarCargoFuncionario, "Cargo", Color.Gray);
            resetarDropDown(dropAlterarIdadeFuncionario, "Idade", Color.Gray);
        }
        void carregarImagemFuncionario()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                pcbAlterarFotoFuncionario.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                AlterarFotoFuncionario = stream.ToArray();
            }
        }
        private void popularAlterarFuncionarioDGV()
        {
            DataTable dataTable = ControleFuncionario.PopularDGVFuncionario();

            if (dataTable != null)
            {
                alterarFuncionarioDGV.DataSource = dataTable;
            }
            else
            {
                notify.Show(this, "Erro ao carregar dados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
        }

        private void btnAlterarFuncionario_Click(object sender, EventArgs e)
        {
            if (txtAlterarIDFuncionario.Text.Length == 0)
            {
                notify.Show(this, "Selecione um Funcionario antes", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                Utilidades.limparCampos(this, pcbAlterarFotoFuncionario);
                resetarDropDown(dropAlterarGeneroFuncionario, "Genero", Color.Gray);
                resetarDropDown(dropAlterarCargoFuncionario, "Cargo", Color.Gray);
                resetarDropDown(dropAlterarIdadeFuncionario, "Idade", Color.Gray);
                return;
            }
            carregarImagemFuncionario();

            int id = int.Parse(txtAlterarIDFuncionario.Text);
            string nome = txtAlterarNomeFuncionario.Text;
            string sobrenome = txtAlterarSobrenomeFuncionario.Text;
            string cpf = txtAlterarCPFFuncionario.Text;
            string genero = dropAlterarGeneroFuncionario.Text;
            string idade = dropAlterarIdadeFuncionario.Text;
            string cargo = dropAlterarCargoFuncionario.Text;
            string usuario = txtAlterarUsuarioFuncionario.Text;
            string senha = txtAlterarSenhaFuncionario.Text;
            byte[] foto = AlterarFotoFuncionario;


            ControleFuncionario.EditarFuncionario(id, nome, sobrenome, cpf, genero, idade, cargo, usuario, senha, foto);
            popularAlterarFuncionarioDGV();
            btnAlterarLimparFuncionario_Click(sender, e);
        }

        private void pcbAlterarFotoFuncionario_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                AlterarFotoFuncionario = File.ReadAllBytes(caminhoArquivo);

               pcbAlterarFotoFuncionario.Image = Image.FromFile(caminhoArquivo);
            }
        }
        private void btnAlterarDeletarFuncionario_Click(object sender, EventArgs e)
        {
            int id = string.IsNullOrEmpty(txtAlterarIDFuncionario.Text) ? 0 : int.Parse(txtAlterarIDFuncionario.Text);

            ControleFuncionario.DeletarFuncionario(id, txtAlterarIDFuncionario);
            popularAlterarFuncionarioDGV();
            btnAlterarLimparFuncionario_Click(sender, e);
        }

        private void AlterarFuncionarioDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAlterarIDFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtAlterarNomeFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtAlterarSobrenomeFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtAlterarCPFFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[3].Value.ToString();
            dropAlterarGeneroFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[4].Value.ToString();
            dropAlterarIdadeFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[5].Value.ToString();
            dropAlterarCargoFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[6].Value.ToString();
            txtAlterarUsuarioFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[7].Value.ToString();
            txtAlterarSenhaFuncionario.Text = alterarFuncionarioDGV.SelectedRows[0].Cells[8].Value.ToString();
            pcbAlterarFotoFuncionario.Image = (Image)new ImageConverter().ConvertFrom(alterarFuncionarioDGV.SelectedRows[0].Cells[9].Value);


            dropAlterarGeneroFuncionario.ForeColor = Color.White;
            dropAlterarCargoFuncionario.ForeColor =Color.White;
            dropAlterarIdadeFuncionario.ForeColor = Color.White;
        }

        private void tabPage10_Enter(object sender, EventArgs e)
        {
            popularAlterarFuncionarioDGV();
        }

        private void txtAlterarCPFFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtAlterarClienteCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void pcbAlterarClienteFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg;*.png;*.jpeg;*.ico|*.jpg;*.png;*.jpeg;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;
                AlterarFotoCliente = File.ReadAllBytes(caminhoArquivo);

                pcbAlterarClienteFoto.Image = Image.FromFile(caminhoArquivo);
            }
        }
        private void popularAlterarClienteDGV()
        {
            DataTable dataTable = ControleCliente.PopularDGVClientes();

            if (dataTable != null)
            {
                alterarClienteDGV.DataSource = dataTable;
            }
            else
            {
                notify.Show(this, "Erro ao carregar dados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
        }

        private void tabPage11_Enter(object sender, EventArgs e)
        {
            popularAlterarClienteDGV();
        }

        private void tabPage11_Leave(object sender, EventArgs e)
        {
            btnAlterarClienteLimpar_Click(sender, e);
        }

        private void btnAlterarClienteLimpar_Click(object sender, EventArgs e)
        {
            Utilidades.limparCampos(this, pcbAlterarClienteFoto);
            resetarDropDown(dropAlterarClienteGenero, "Genero", Color.Gray);
            resetarDropDown(dropAlterarClienteIdade, "Idade", Color.Gray);
        }

        private void btnAlterarClienteDeletar_Click(object sender, EventArgs e)
        {
            int id = string.IsNullOrEmpty(txtAlterarClienteID.Text) ? 0 : int.Parse(txtAlterarClienteID.Text);

            ControleCliente.DeletarCliente(id, txtAlterarClienteID);
            popularAlterarClienteDGV();
            btnAlterarClienteLimpar_Click(sender, e);
        }

        private void alterarClienteDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAlterarClienteID.Text = alterarClienteDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtAlterarClienteNome.Text = alterarClienteDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtAlterarClienteSobrenome.Text = alterarClienteDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtAlterarClienteCPF.Text = alterarClienteDGV.SelectedRows[0].Cells[3].Value.ToString();
            dropAlterarGenero.Text = alterarClienteDGV.SelectedRows[0].Cells[4].Value.ToString();
            dropAlterarClienteIdade.Text = alterarClienteDGV.SelectedRows[0].Cells[5].Value.ToString();
            txtAlterarClienteTelefone.Text = alterarClienteDGV.SelectedRows[0].Cells[6].Value.ToString();
            txtAlterarClienteEndereco.Text = alterarClienteDGV.SelectedRows[0].Cells[7].Value.ToString();
            txtAlterarClienteUsuario.Text = alterarClienteDGV.SelectedRows[0].Cells[8].Value.ToString();
            txtAlterarClienteSenha.Text = alterarClienteDGV.SelectedRows[0].Cells[9].Value.ToString();
            pcbAlterarClienteFoto.Image = (Image)new ImageConverter().ConvertFrom(alterarClienteDGV.SelectedRows[0].Cells[10].Value);


            dropAlterarClienteGenero.ForeColor = Color.White;
            dropAlterarClienteIdade.ForeColor = Color.White;
        }
        void carregarImagemCliente()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                pcbAlterarClienteFoto.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                AlterarFotoCliente = stream.ToArray();
            }
        }
        private void btnAlterarClienteAlterar_Click(object sender, EventArgs e)
        {
            if (txtAlterarClienteID.Text.Length == 0)
            {
                notify.Show(this, "Selecione um Cliente antes", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                Utilidades.limparCampos(this, pcbAlterarClienteFoto);
                resetarDropDown(dropAlterarClienteGenero, "Genero", Color.Gray);
                resetarDropDown(dropAlterarClienteIdade, "Idade", Color.Gray);
                return;
            }
            carregarImagemCliente();

            int id = int.Parse(txtAlterarClienteID.Text);
            string nome = txtAlterarClienteNome.Text;
            string sobrenome = txtAlterarClienteSobrenome.Text;
            string cpf = txtAlterarClienteCPF.Text;
            string genero = dropAlterarGenero.Text;
            string idade = dropAlterarClienteIdade.Text;
            string telefone = txtAlterarClienteTelefone.Text;
            string endereco = txtAlterarClienteEndereco.Text;
            string usuario = txtAlterarClienteUsuario.Text;
            string senha = txtAlterarClienteSenha.Text;
            byte[] foto = AlterarFotoCliente;

            ControleCliente.EditarCliente(id, nome, sobrenome, cpf, genero, idade, telefone, endereco, usuario, senha, foto);
            popularAlterarClienteDGV();
            btnAlterarClienteLimpar_Click(sender, e);
        }
        private void LimitarAcessoFuncionarios()
        {
            if (!ControleFuncionario.VerificarGerencia(UsuarioLogado.usuario))
            {
                btnAdicionarFuncionario.Enabled = false;
                btnGerenciarFuncionario.Enabled = false;
            }
        }
        private void LimitarAcessoCliente()
        {
            if(UsuarioLogado.efuncionario == false)
            {
                btnAdicionar.Visible = false;
                btnDinheiro.Visible = false;
            }
        }
        private void LimitarAcessoExplorar()
        {
            if (UsuarioLogado.explorar == true)
            {
                btnCasa.Visible = false;
                btnAdicionar.Visible = false;
                btnDinheiro.Visible = false;
            }
        }
        
    }
}