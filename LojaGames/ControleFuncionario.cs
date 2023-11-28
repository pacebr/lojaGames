using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace LojaGames
{
    internal class ControleFuncionario
    {

        public static bool VerificarCredenciais(string usuario, string senha) // verificar Login
        {
            Conexao.Conectar();
            string sql = "SELECT usuario, senha FROM funcionarios.dados WHERE usuario = @usuario AND senha = @senha";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("usuario", usuario);
            cmd.Parameters.AddWithValue("senha", Criptografia.ToSHA256(senha));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                Conexao.Fechar();
                return true;
            }
            Conexao.Fechar();
            return false;
        }
        public static bool VerificarGerencia(string usuario) // verificar cargo
        {
            Conexao.Conectar();

            string cargo = "";
            bool isGerente = false;

            string sql = "SELECT cargo FROM funcionarios.dados WHERE usuario = @usuario";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cargo = reader["cargo"] as string;
                }
            }
            if (cargo == "Gerente")
                isGerente = true;

            Conexao.Fechar();

            return isGerente;
        }
        public static bool CriarUsuario(string nome, string cargo,string usuario, string senha, byte[] foto, string genero)
        {
            try
            {
                senha = Criptografia.ToSHA256(senha);
                Conexao.Conectar();
                string dml = "insert into funcionarios.dados (nome,cargo,usuario,senha,foto,genero) values (@nome, @cargo, @usuario, @senha, @foto, @genero)";
                SqlCommand com = new SqlCommand(dml, Conexao.conn);
                com.Parameters.AddWithValue("@nome", nome);
                com.Parameters.AddWithValue("@cargo", cargo);
                com.Parameters.AddWithValue("@usuario", usuario);
                com.Parameters.AddWithValue("@senha", senha);
                com.Parameters.AddWithValue("@foto", foto);
                com.Parameters.AddWithValue("@genero", genero);

                com.ExecuteNonQuery();
                Conexao.Fechar();
                return true;
            }
            catch (Exception ex)
            {
                Conexao.Fechar();
                System.Windows.Forms.MessageBox.Show("erro:" + ex);
                return false;
            }
        }
    }
}