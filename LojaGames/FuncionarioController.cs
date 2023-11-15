using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using senac_biblioteca.Controllers;
using System.Drawing;

namespace LojaGames
{
    internal class FuncionarioController
    {

        public static bool VerificarCredenciais(string usuario, string senha) // verificar Login
        {
            Conexao.Conectar();
            string sql = "SELECT * FROM funcionarios.dados WHERE usuario = @usuario AND senha = @senha";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("usuario", usuario);
            cmd.Parameters.AddWithValue("senha", senha);

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

        public static void Enviar(byte[] foto, string valor)
        {
            Conexao.Conectar();
            string sql = "INSERT INTO jogos.dados (imagem, nome) " +
                "VALUES (@imagem, @valor)";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);


            cmd.Parameters.AddWithValue("@imagem", foto);
            cmd.Parameters.AddWithValue(@"valor", valor);
            
            cmd.ExecuteNonQuery();

            Conexao.Fechar();
        }
      
    }
}