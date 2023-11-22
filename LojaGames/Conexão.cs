using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaGames
{
    public static class Conexao
    {
        public static SqlConnection conn;

        private static SqlConnection conexaoBanco()
        {
            var conexaoCasa = new SqlConnection(
                @"Data Source=exodusgamestore.database.windows.net; User ID=vgdsno; Password=Vgdsn@05031906; initial catalog=exodusDb;"  //Connection Timeout = 1;
            );
            var conexaoCurso = new SqlConnection(
                @"Data Source=SJC0562934W10-1; User ID=sa; Password=Senac123; Initial Catalog=exodusDb"
            );

            try
            {
                conn = conexaoCasa;

            }
            catch (Exception)
            {
                conn = conexaoCurso;
            }

            return conn;
        }

        public static void Conectar()
        {
             conexaoBanco().Open();
        }

        public static void Fechar()
        {
            conexaoBanco().Close();
        }
    }
}
