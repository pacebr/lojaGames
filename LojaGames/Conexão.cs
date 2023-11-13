using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using senac_biblioteca.Controllers;

namespace senac_biblioteca.Controllers
{
    public static class Conexao
    {
        public static SqlConnection conn;

        private static SqlConnection conexaoBanco()
        {
            var conexaoCasa = new SqlConnection(
                @"Data Source=localhost\SQLEXPRESS; integrated security=SSPI;initial catalog=exodusDb; Connection Timeout = 1;"
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
