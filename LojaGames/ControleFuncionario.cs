using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Bunifu.UI.WinForms;

namespace LojaGames
{
    internal class ControleFuncionario
    {
        public static Image ObterImagemDoFuncionarioPeloID(int idFuncionario)
        {
            try
            {
                Conexao.Conectar();
                string sql = "SELECT foto FROM funcionarios.dados WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, Conexao.conn))
                {
                    cmd.Parameters.AddWithValue("@id", idFuncionario);

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
        public static string ObterNomeFuncionario(int id)
        {
            try
            {
                Conexao.Conectar();
                string sql = "SELECT nome FROM funcionarios.dados WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, Conexao.conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return dr["nome"].ToString();
                        }
                        else
                        {
                            return string.Empty; // Retornar uma string vazia se o funcionário não for encontrado
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Considere usar um mecanismo de log aqui em vez de MessageBox
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
            string sql = "SELECT * FROM funcionarios.dados WHERE id = @id";
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
            }
            catch(Exception)
            {
                Conexao.Fechar();
            }
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
        public static bool AdicionarFuncionario(string nome,string sobrenome,string CPF,string genero,string idade, string cargo,string usuario, string senha, byte[] foto)
        {
            menu menu = new menu();
            BunifuSnackbar notificacao = new BunifuSnackbar();
            try
            {
                senha = Criptografia.ToSHA256(senha);
                Conexao.Conectar();
                string dml = "insert into funcionarios.dados (nome,sobrenome,CPF,genero,idade,cargo,usuario,senha,foto) values (@nome, @sobrenome, @CPF, @genero, @idade, @cargo, " +
                    "@usuario, @senha, @foto)";
                SqlCommand com = new SqlCommand(dml, Conexao.conn);
                com.Parameters.AddWithValue("@nome", nome);
                com.Parameters.AddWithValue("@sobrenome", sobrenome);
                com.Parameters.AddWithValue("@CPF", CPF);
                com.Parameters.AddWithValue("@genero", genero);
                com.Parameters.AddWithValue("@idade", idade);
                com.Parameters.AddWithValue("@cargo", cargo);
                com.Parameters.AddWithValue("@usuario", usuario);
                com.Parameters.AddWithValue("@senha", senha);
                com.Parameters.AddWithValue("@foto", foto);

                com.ExecuteNonQuery();
                notificacao.Show(menu, "Funcionario cadastrado com sucesso.", BunifuSnackbar.MessageTypes.Success);
                Conexao.Fechar();
                return true;
            }
            catch (Exception ex)
            {
                Conexao.Fechar();
                notificacao.Show(menu, "erro ao cadastrar funcionario.", BunifuSnackbar.MessageTypes.Warning);
                return false;
            }
        }
        public static bool EditarFuncionario(int id, string nome, string sobrenome, string cpf, string genero, string idade, string cargo,
          string usuario, string senha, byte[] foto)
        {
            menu menu = new menu();
            BunifuSnackbar notificacao = new BunifuSnackbar();

            Conexao.Conectar();

            string sql = "UPDATE funcionarios.dados SET nome = @nome, sobrenome = @sobrenome, cpf = @cpf, " +
              "genero = @genero, idade = @idade, cargo = @cargo, usuario = @usuario, senha = @senha, foto = @foto WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
            try
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@idade", idade);
                cmd.Parameters.AddWithValue("@cargo", cargo);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", Criptografia.ToSHA256(senha));
                cmd.Parameters.AddWithValue("@foto", foto);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                Conexao.Fechar();
                notificacao.Show(menu, "Funcionario alterado com sucesso.", BunifuSnackbar.MessageTypes.Success);
            }
            catch (Exception ex)
            {
                notificacao.Show(menu, $"Erro ao alterar o funcionario: {ex.Message}", BunifuSnackbar.MessageTypes.Error);
            }
            Conexao.Fechar();
            return false;
        }

        public static DataTable PopularDGVFuncionario()
        {
            Conexao.Conectar();

            string sql = "SELECT * FROM funcionarios.dados";
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
        public static bool DeletarFuncionario(int id, Bunifu.UI.WinForms.BunifuTextBox txtAlterarID)
        {
            menu menu = new menu();
            BunifuSnackbar notificacao = new BunifuSnackbar();

            if (id <= 0 || string.IsNullOrWhiteSpace(txtAlterarID.Text))
            {
                notificacao.Show(menu, "Selecione um funcionario primeiro.", BunifuSnackbar.MessageTypes.Warning);
            }

            Conexao.Conectar();

            string sql = "DELETE FROM funcionarios.dados WHERE id = " + id + ";";

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
    }
}