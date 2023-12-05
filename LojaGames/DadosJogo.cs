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
        public static void EnviarDadosJogo(byte[] imagem, string jogo, string descricao, byte[] icone, byte[] carousel, string trailer)
        {
            Conexao.Conectar();
            string sql = "INSERT INTO jogos.dados (imagem, jogo, descricao, icone, carousel, trailer) " + "VALUES (@imagem, @jogo, @descricao, @icone, @carousel, @trailer)";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("@imagem", imagem);
            cmd.Parameters.AddWithValue(@"jogo", jogo);
            cmd.Parameters.AddWithValue(@"descricao", descricao);
            cmd.Parameters.AddWithValue(@"icone", icone);
            cmd.Parameters.AddWithValue(@"carousel", carousel);
            cmd.Parameters.AddWithValue(@"trailer", trailer);


            cmd.ExecuteNonQuery();

            Conexao.Fechar();
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
        public static string DadosDescricao(int id)
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
    }
}   