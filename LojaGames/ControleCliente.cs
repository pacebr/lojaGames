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
    internal class ControleCliente
    {
        public static bool VerificarCredenciais(string usuario, string senha) // verificar Login
        {
            Conexao.Conectar();
            string sql = "SELECT * FROM clientes.dados WHERE usuario = @usuario AND senha = @senha";

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
        public static void AddCliente(string usuario, string nome, string senha, string email,
                                      int idade, string cpf, string telefone, string endereco, byte[] foto)
        {
            if (usuario.Length == 0 || nome.Length == 0 || senha.Length == 0 || email.Length == 0 ||
                idade <= 0 || cpf.Length == 0 || telefone.Length == 0 || endereco.Length == 0)
            {
                MessageBox.Show("Uma ou mais informações incorretas.");
                return;
            }
            Conexao.Conectar();

            string sql = "INSERT INTO clientes.dados (usuario, nome, senha, email, idade, cpf, telefone, endereco, foto) " +
                "VALUES (@usuario, @nome, @senha, @email, @idade, @cpf, @telefone, @endereco, @foto)";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@idade", idade);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@foto", foto);

            cmd.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}