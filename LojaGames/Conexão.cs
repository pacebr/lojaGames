using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;

namespace LojaGames
{
    public static class Conexao
    {
        public static SqlConnection conn;

        private static SqlConnection conexaoBanco()
        {
            var conexao = new SqlConnection(
                @"Data Source=exodusgamestore.database.windows.net; User ID=vgdsno; Password=Vgdsn@05031906; initial catalog=exodusDb;"
            );          
            conn = conexao;

            return conn;
        }

        public static void Conectar()
        {
            try
            {
                conexaoBanco().Open();
            }
            catch ( Exception ex )
            {
                login login = new login();
                BunifuSnackbar notificacao = new BunifuSnackbar();
                notificacao.Show(login, "Erro na conexão: " + ex.Message, BunifuSnackbar.MessageTypes.Error);
                return;
            }
        }

        public static void Fechar()
        {
            conexaoBanco().Close();
        }
    }
}