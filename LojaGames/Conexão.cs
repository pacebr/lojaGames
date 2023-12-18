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
            //var conexao = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; integrated security=SSPI;initial catalog=exodusDb");
            var conexao = new SqlConnection(@"Data Source=SJC0562934W10-1; User ID=sa; Password=Senac123; Initial Catalog=exodusDb");          
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
                notificacao.Show(login, "Erro ao abrir conexão: " + ex.Message, BunifuSnackbar.MessageTypes.Error);
                return;
            }
        }

        public static void Fechar()
        {
            try
            {
                conexaoBanco().Close();
            }
            catch (Exception ex)
            {
                login login = new login();
                BunifuSnackbar notificacao = new BunifuSnackbar();
                notificacao.Show(login, "Erro ao fechar conexão: " + ex.Message, BunifuSnackbar.MessageTypes.Error);
                return;
            }
        }
    }
}