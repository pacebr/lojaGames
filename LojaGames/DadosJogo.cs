using System;
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

namespace LojaGames
{
    public static class DadosJogo
    {
        public static void EnviarDadosIcone(byte[] foto, string nome)
        {
            Conexao.Conectar();
            string sql = "INSERT INTO icone.dados (imagem, nome) " + "VALUES (@imagem, @valor)";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("@imagem", foto);
            cmd.Parameters.AddWithValue(@"valor", nome);

            cmd.ExecuteNonQuery();

            Conexao.Fechar();
        }
        public static void EnviarDadosJogo(byte[] imagem, string jogo, string descricao)
        {
            Conexao.Conectar();
            string sql = "INSERT INTO jogos.dados (imagem, nome, descricao) " + "VALUES (@imagem, @nome, @descricao)";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("@imagem", imagem);
            cmd.Parameters.AddWithValue(@"nome", jogo);
            cmd.Parameters.AddWithValue(@"descricao", descricao);

            cmd.ExecuteNonQuery();

            Conexao.Fechar();
        }
        public static void EnviarDadosCarousel(byte[] icone, byte[] imagem, string jogo, string descricao)
        {
            Conexao.Conectar();
            string sql = "INSERT INTO carousel.dados (icone, imagem, jogo, descricao) " + "VALUES (@icone, @imagem, @jogo, @descricao)";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("@icone", icone);
            cmd.Parameters.AddWithValue("@imagem", imagem);
            cmd.Parameters.AddWithValue(@"jogo", jogo);
            cmd.Parameters.AddWithValue(@"descricao", descricao);

            cmd.ExecuteNonQuery();

            Conexao.Fechar();
        }
        public static Image PegarImagemPequena(int id)
        {
            try
            {
                Conexao.Conectar();
                string sql = "select icone from carousel.dados where id = " + id;
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

        public static string PegarTexto(int id)
        {
            Conexao.Conectar();
            string sql = "select jogo from carousel.dados where id = " + id;
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

        public static Image PegarImagemCarrousel(int id)
        {
            try
            {
                Conexao.Conectar();
                string sql = "select imagem from carousel.dados where id = " + id;
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
    }
}   