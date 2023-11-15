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

        public static Image Imgcontrol()
        {
            string imagePath =
                @"C:\Users\victor.gsnogueira\source\repos\lojaGames\LojaGames\Resources\5260498.png";
            Image image = Image.FromFile(imagePath);

            return image;
        }

        public static Image PegarImagem()
        {
            Conexao.Conectar();
            string sql = "SELECT (imagem) from jogos.dados";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            {
                var arrByte = cmd.ExecuteScalar() as byte[];

                using (var ms = new MemoryStream(arrByte))
                {
                    return Image.FromStream(ms);
                }
            }
            
        }
        public static string PegarTexto()
        {
            Conexao.Conectar();
            string sql = "select nome from jogos.dados where id = 1";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            
            string buttonText = cmd.ExecuteScalar().ToString();
            Conexao.Fechar();
            return buttonText;
        }
      
    }
}