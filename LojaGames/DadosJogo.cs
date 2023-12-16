using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using LojaGames.Properties;
using Bunifu.UI.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LojaGames
{
    public static class DadosJogo
    {
        public static void EnviarDadosJogo(string jogo, byte[] imagem, string descricao, byte[] icone, byte[] carousel, string trailer, string preco, string genero, float? desconto , menu menu)
        {
            BunifuSnackbar notificacao = new BunifuSnackbar();

            Conexao.Conectar();

            if (JogoDescricaoJaExistem(jogo, descricao))
            {
                notificacao.Show(menu, "Jogo ou descrição já existem na tabela.", BunifuSnackbar.MessageTypes.Warning);
                Conexao.Fechar();
                return;
            }
            if (genero.Trim() == "Genero")
            {
                notificacao.Show(menu, "Selecione um gênero válido.", BunifuSnackbar.MessageTypes.Warning);
                Conexao.Fechar();
                return;
            }

            if (string.IsNullOrWhiteSpace(jogo) || string.IsNullOrWhiteSpace(descricao) || string.IsNullOrWhiteSpace(preco) || string.IsNullOrWhiteSpace(genero))
            {
                notificacao.Show(menu, "Preencha todos os campos obrigatórios.", BunifuSnackbar.MessageTypes.Warning);
                Conexao.Fechar();
                return;
            }

            if (!decimal.TryParse(preco, out decimal precoDecimal))
            {
                notificacao.Show(menu, "O preço inserido não é válido.", BunifuSnackbar.MessageTypes.Warning);
                Conexao.Fechar();
                return;
            }

            if (imagem == null || icone == null || carousel == null)
            {
                notificacao.Show(menu, "Selecione imagens para o jogo.", BunifuSnackbar.MessageTypes.Warning);
                Conexao.Fechar();
                return;
            }

            if (!string.IsNullOrWhiteSpace(trailer) && !Uri.IsWellFormedUriString(trailer, UriKind.Absolute))
            {
                notificacao.Show(menu, "A URL do trailer não é válida.", BunifuSnackbar.MessageTypes.Warning);
                Conexao.Fechar();
                return;
            }

            string sql = "INSERT INTO jogos.dados (jogo, imagem, descricao, icone, carousel, trailer, preco, genero, desconto) " +
                          "VALUES (@jogo, @imagem, @descricao, @icone, @carousel, @trailer, @preco, @genero, ISNULL(@desconto, NULL))";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("@jogo", jogo);
            cmd.Parameters.AddWithValue("@imagem", imagem);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            cmd.Parameters.AddWithValue("@icone", icone);
            cmd.Parameters.AddWithValue("@carousel", carousel);
            cmd.Parameters.AddWithValue("@trailer", trailer);
            cmd.Parameters.AddWithValue("@preco", precoDecimal);
            cmd.Parameters.AddWithValue("@genero", genero);
            cmd.Parameters.AddWithValue("@desconto", (object)desconto ?? DBNull.Value);

            try
            {
                cmd.ExecuteNonQuery();
                notificacao.Show(menu, "Jogo cadastrado com sucesso.", BunifuSnackbar.MessageTypes.Success);
            }
            catch (Exception ex)
            {
                notificacao.Show(menu, $"Erro ao cadastrar o jogo: {ex.Message}", BunifuSnackbar.MessageTypes.Error);
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        private static bool JogoDescricaoJaExistem(string jogo, string descricao)
        {
            Form formulario = new Form();
            BunifuSnackbar notificacao = new BunifuSnackbar();

            try
            {
                string sql = "SELECT COUNT(*) FROM jogos.dados WHERE jogo = @jogo OR descricao = @descricao";
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                cmd.Parameters.AddWithValue("@jogo", jogo);
                cmd.Parameters.AddWithValue("@descricao", descricao);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                notificacao.Show(formulario, $"Erro ao verificar a existência do jogo/descrição: {ex.Message}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                return false;
            }
        }


        public static Image PegarIcone(int id)
        {
            try
            {
                Conexao.Conectar();
                string sql = "select icone from jogos.dados where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                var arrByte = cmd.ExecuteScalar() as byte[];

                using (var ms = new MemoryStream(arrByte))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                Image imagemErro = Resources.Error;
                return imagemErro;
            }
        }

        public static string PegarJogo(int id)
        {
            Conexao.Conectar();
            string sql = "select jogo from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string buttonText = cmd.ExecuteScalar().ToString();
                return buttonText;
            }
            return "Jogo não cadastrado";
        }
        public static Image PegarImagemCarrousel(int id)
        {
            try
            {
                Conexao.Conectar();
                string sql = "select carousel from jogos.dados where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                var arrByte = cmd.ExecuteScalar() as byte[];

                using (var ms = new MemoryStream(arrByte))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                Image imagemErro = Resources.Error;
                return imagemErro;
            }
        }

        public static Image PegarImagemGrande(int id)
        {
            try
            {
                Conexao.Conectar();
                string sql = "select imagem from jogos.dados where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                var arrByte = cmd.ExecuteScalar() as byte[];

                using (var ms = new MemoryStream(arrByte))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }
        public static int ObterNumeroImagens()
        {
            try
            {
                Conexao.Conectar();
                string sql = "select count(*) from jogos.dados";
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                int numeroImagens = (int)cmd.ExecuteScalar();

                return numeroImagens;
            }
            catch
            {
                return 0;
            }
        }
        public static string PegarTrailer(int id)
        {
            Conexao.Conectar();
            string sql = "select trailer from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string buttonText = cmd.ExecuteScalar().ToString();
                return buttonText;
            }

            return null;
        }
        public static string PegarPreco(int id)
        {
            Conexao.Conectar();
            string sql = "select preco from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string buttonText = cmd.ExecuteScalar().ToString();
                return buttonText;
            }

            return null;
        }
        public static string PegarDesconto(int id)
        {
            Conexao.Conectar();
            string sql = "select desconto from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string buttonText = cmd.ExecuteScalar().ToString();
                return buttonText;
            }

            return null;
        }

        public static string PegarGenero(int id)
        {
            Conexao.Conectar();
            string sql = "select genero from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string buttonText = cmd.ExecuteScalar().ToString();
                return buttonText;
            }

            return null;
        }
        public static string ObterLinkIncorporado(string url)
        {
            if (url.Contains("youtube.com"))
            {
                var videoId = ExtrairVideoId(url);

                if (!string.IsNullOrEmpty(videoId))
                {
                    return $"https://www.youtube.com/embed/{videoId}?controls=0";
                }
            }

            return null;
        }
        private static string ExtrairVideoId(string url)
        {
            return HttpUtility.ParseQueryString(new Uri(url).Query)["v"];
        }
        public static string PegarDescricao(int id)
        {
            Conexao.Conectar();
            string sql = "select descricao from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                string buttonText = cmd.ExecuteScalar().ToString();
                return buttonText;
            }
            else
            {
                return "Jogo não cadastrado";
            }
        }

        public static bool DeletarJogo(int id, Bunifu.UI.WinForms.BunifuTextBox txtAlterarID)
        {
            menu menu = new menu();
            BunifuSnackbar notificacao = new BunifuSnackbar();

            if (id <= 0 || string.IsNullOrWhiteSpace(txtAlterarID.Text))
            {
                notificacao.Show(menu, "Selecione um jogo primeiro.", BunifuSnackbar.MessageTypes.Warning);
            }

            Conexao.Conectar();

            string sql = "DELETE FROM jogos.dados WHERE id = " + id + ";";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                cmd.ExecuteNonQuery();

                Conexao.Fechar();
                return true;
            }
            catch (Exception ex)
            {
                notificacao.Show(menu, $"Erro ao Deletar o jogo: {ex.Message}", BunifuSnackbar.MessageTypes.Error);
            }
            Conexao.Fechar();
            return false;
        }

        public static bool EditarJogo(int id, string jogo, byte[] imagem, string descricao, byte[] icone, byte[] carousel,
           string trailer, float preco, string genero, float? desconto)
        {
            menu menu = new menu();
            BunifuSnackbar notificacao = new BunifuSnackbar();

            Conexao.Conectar();

            string sql = "UPDATE jogos.dados SET jogo = @jogo, imagem = @imagem, descricao = @descricao, " +
              "icone = @icone, carousel = @carousel, trailer = @trailer, preco = @preco, genero = @genero, desconto = @desconto WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            try
            {
                cmd.Parameters.AddWithValue("@jogo", jogo);
                cmd.Parameters.AddWithValue("@imagem", imagem);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@icone", icone);
                cmd.Parameters.AddWithValue("@carousel", carousel);
                cmd.Parameters.AddWithValue("@trailer", trailer);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@desconto", desconto);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                Conexao.Fechar();
                notificacao.Show(menu,"Jogo alterado com sucesso.", BunifuSnackbar.MessageTypes.Success);
            }
            catch (Exception ex)
            {
                notificacao.Show(menu, $"Erro ao cadastrar o jogo: {ex.Message}", BunifuSnackbar.MessageTypes.Error);
            }
            Conexao.Fechar();
            return false;
        }
        public static DataTable PopularDGV()
        {
            Conexao.Conectar();

            string sql = "SELECT * FROM jogos.dados";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                return dataTable;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                Conexao.Fechar();
            }
        }
    }
}