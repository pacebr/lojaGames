using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Bunifu.UI.WinForms;

namespace LojaGames
{
    internal class ControleCliente
    {
        public static Image ObterImagemDoClientePeloID(int idCliente)
        {
            try
            {
                Conexao.Conectar();
                string sql = "SELECT foto FROM clientes.dados WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, Conexao.conn))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Converter a imagem do banco de dados (byte[]) para Image
                        byte[] bytes = (byte[])result;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        return null; // Ou outra imagem padrão se a imagem não for encontrada
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Ou outra imagem padrão se ocorrer um erro
            }
            finally
            {
                Conexao.Fechar();
            }
        }
        public static string ObterNomeCliente(int id)
        {
            try
            {
                Conexao.Conectar();
                string sql = "SELECT nome, sobrenome FROM clientes.dados WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, Conexao.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string nome = dr["nome"].ToString();
                            string sobrenome = dr["sobrenome"].ToString();

                            return $"{nome} {sobrenome}";
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                Conexao.Fechar();
            }
        }
        public static bool VerificarExistencia(int id) // verificar existencia
        {
            Conexao.Conectar();
            string sql = "SELECT * FROM clientes.dados WHERE id = @id";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Conexao.Fechar();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e);
            }
            Conexao.Fechar();
            return false;
        }

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
            BunifuSnackbar notificacao = new BunifuSnackbar();
            menu menu = new menu();
            string senhaHasheada = Criptografia.ToSHA256(senha);

            if (nome.Length == 0 || sobrenome.Length == 0 || usuario.Length == 0 || senha.Length == 0 || idade.Length == 0 || genero.Length == 0 || cpf.Length == 0 || telefone.Length == 0 || endereco.Length == 0)
            {
                notificacao.Show(menu, "Uma ou mais informações incorretas.", BunifuSnackbar.MessageTypes.Warning);
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

            try
            {
                cmd.ExecuteNonQuery();
                notificacao.Show(menu, "cadastro realizado com sucesso.", BunifuSnackbar.MessageTypes.Success);
            }
            catch (Exception)
            {

                throw;
            }
           

            Conexao.Fechar();
        }
        public static DataTable PopularDGVClientes()
        {
            Conexao.Conectar();

            string sql = "SELECT * FROM Clientes.dados";
            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                return dataTable;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                Conexao.Fechar();
            }
        }
        public static bool DeletarCliente(int id, Bunifu.UI.WinForms.BunifuTextBox txtAlterarID)
        {
            menu menu = new menu();
            BunifuSnackbar notificacao = new BunifuSnackbar();

            if (id <= 0 || string.IsNullOrWhiteSpace(txtAlterarID.Text))
            {
                notificacao.Show(menu, "Selecione um cliente primeiro.", BunifuSnackbar.MessageTypes.Warning);
            }

            Conexao.Conectar();

            string sql = "DELETE FROM clientes.dados WHERE id = " + id + ";";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                cmd.ExecuteNonQuery();

                Conexao.Fechar();
                return true;
            }
            catch (Exception ex)
            {
                notificacao.Show(menu, $"Erro ao Deletar o funcionario: {ex.Message}", BunifuSnackbar.MessageTypes.Error);
            }
            Conexao.Fechar();
            return false;
        }
        public static bool EditarCliente(int id, string nome, string sobrenome, string cpf, string genero, string idade, string telefone, string endereco,
         string usuario, string senha, byte[] foto)
        {
            menu menu = new menu();
            BunifuSnackbar notificacao = new BunifuSnackbar();

            Conexao.Conectar();

            string sql = "UPDATE clientes.dados SET nome = @nome, sobrenome = @sobrenome, cpf = @cpf, " +
              "genero = @genero, idade = @idade, telefone = @telefone, endereco = @endereco, usuario = @usuario, senha = @senha, foto = @foto WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            try
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@idade", idade);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@endereco", endereco);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", Criptografia.ToSHA256(senha));
                cmd.Parameters.AddWithValue("@foto", foto);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                Conexao.Fechar();
                notificacao.Show(menu, "Cliente alterado com sucesso.", BunifuSnackbar.MessageTypes.Success);
            }
            catch (Exception ex)
            {
                notificacao.Show(menu, $"Erro ao alterar o cliente: {ex.Message}", BunifuSnackbar.MessageTypes.Error);
            }
            Conexao.Fechar();
            return false;
        }
    }
}