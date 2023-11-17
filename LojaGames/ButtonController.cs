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
using senac_biblioteca.Controllers;

namespace LojaGames
{
    public static class ButtonController
    {
        public static Image PegarImagem(int id)
        {
            Conexao.Conectar();
            string sql = "select imagem from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            {
                var arrByte = cmd.ExecuteScalar() as byte[];

                using (var ms = new MemoryStream(arrByte))
                {
                    return Image.FromStream(ms);
                }
            }

        }
        public static string PegarTexto(int id)
        {
            Conexao.Conectar();
            string sql = "select nome from jogos.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            string buttonText = cmd.ExecuteScalar().ToString();
            Conexao.Fechar();
            return buttonText;
        }
        public static Image PegarImagemJogo(int id)
        {
            Conexao.Conectar();
            string sql = "select imagem from carousel.dados where id = " + id;
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            {
                var arrByte = cmd.ExecuteScalar() as byte[];

                using (var ms = new MemoryStream(arrByte))
                {
                    return Image.FromStream(ms);
                }
            }
        }
    }
}