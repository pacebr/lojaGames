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
            try
            {
                Conexao.Conectar();
                string sql = "SELECT usuario, senha FROM clientes.dados WHERE usuario = @usuario AND senha = @senha";
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("senha", Criptografia.ToSHA256(senha));

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Conexao.Fechar();
                    return true;
                }
            }
            catch
            {
                Conexao.Fechar();
            }          
            return false;
        }
        public static void AddCliente(string nome, string sobrenome, string usuario, string senha, string idade,string genero, string cpf, string telefone, string endereco, byte[] foto)
        {
            string senhaHasheada = Criptografia.ToSHA256(senha);
            if (nome.Length == 0 || sobrenome.Length == 0 || usuario.Length == 0 || senha.Length == 0 || idade.Length == 0 || genero.Length == 0 || cpf.Length == 0 || telefone.Length == 0 || endereco.Length == 0)
            {
                MessageBox.Show("Uma ou mais informações incorretas.");
                return;
            }
            Conexao.Conectar();

            string sql = "INSERT INTO clientes.dados (nome, sobrenome, usuario, senha, idade, genero, cpf, telefone, endereco, foto) " +
                "VALUES (@nome, @sobrenome, @usuario, @senha, @idade, @genero, @cpf, @telefone, @endereco, @foto)";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senhaHasheada);
            cmd.Parameters.AddWithValue("@idade", idade);
            cmd.Parameters.AddWithValue("@genero", genero);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@foto", foto);

            cmd.ExecuteNonQuery();

            Conexao.Fechar();
        }
    }
}