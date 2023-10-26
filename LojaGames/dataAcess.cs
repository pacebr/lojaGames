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
    internal class dataAcess
    {
        private static SqlConnection conexao;
        private static SqlConnection conexaoBanco()
        {
            conexao = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; integrated security=SSPI;initial catalog=lojaGames_db");
            conexao.Open();
            return conexao;
        }
        //Funções Gerais
        public static DataTable dql(string sql)// Select
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SqlDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public static void dml(string q, string msgOK = null, string msgERRO = null)// Insert, Delete e Update
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = conexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = q;
                da = new SqlDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
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
    }
}