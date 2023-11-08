using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LojaGames
{
    internal class ClienteController
    {
        private static SqlConnection conexao;
        private static SqlConnection conexaoBanco()
        {
            var conexaoCasa = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; integrated security=SSPI;initial catalog=exodusDb");
            var conexaoCurso = new SqlConnection(@"Data Source=SJC0562934W10-1; User ID=sa; Password=Senac123; Initial Catalog=exodusDb");

            try
            {
                conexao = conexaoCasa;
                conexao.Open();
            }
            catch (Exception e)
            {
                conexao = conexaoCurso;
                conexao.Open();
            }

            return conexao;
        }
        //Funções Gerais
        public static DataTable dql(string sql) // Select
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conn = conexaoBanco();
                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                da = new SqlDataAdapter(cmd.CommandText, conn);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void dml(string q, string msgOK = null, string msgERRO = null) // Insert, Delete e Update
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var conn = conexaoBanco();
                var cmd = conn.CreateCommand();
                cmd.CommandText = q;
                da = new SqlDataAdapter(cmd.CommandText, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                if (msgOK != null)
                {
                    MessageBox.Show(msgOK);
                }
            }
            catch (Exception ex)
            {
                if (msgERRO != null)
                {
                    MessageBox.Show(msgERRO + "\n" + ex.Message);
                }
                throw ex;
            }

        }
        public static bool VerificarCredenciais(string usuario, string senha) // verificar Login
        {
            int count;
            string sql = "SELECT COUNT(*) FROM clientes.dados WHERE usuario = @usuario AND senha = @senha";
            using (SqlConnection conn = conexaoBanco())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                count = (int)cmd.ExecuteScalar();
                FecharConexao();
                return count > 0;
            }
        }
        public static void FecharConexao()
        {
            if (conexao != null && conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}