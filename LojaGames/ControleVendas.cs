﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaGames
{
    public class ControleVendas
    {
        public static bool AddVendas(string jogo, int quantidade, float valor, int clienteID, int funcionarioID)
        {
            Conexao.Conectar();

            string sql = "INSERT INTO vendas.dados (jogo, quantidade, preco, clienteID, funcionarioID) " +
                "VALUES (@jogo, @quantidade, @valor, @clienteID, @funcionarioID)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                cmd.Parameters.AddWithValue("@jogo", jogo);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@clienteID", clienteID);
                cmd.Parameters.AddWithValue("@funcionarioID", funcionarioID);

                cmd.ExecuteNonQuery();

                Conexao.Fechar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e);
            }
            Conexao.Fechar();
            return false;
        }
        public static bool EditarVendas(int id, string jogo, int quantidade, float valor, int clienteID, int funcionarioID)
        {
            Conexao.Conectar();

            string sql = "UPDATE vendas.dados SET jogo = @jogo, valor = @valor, " +
                "cliente_id = @clienteID, funcionarioID = @funcionarioID WHERE id = @id";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);

                cmd.Parameters.AddWithValue("@jogo", jogo);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@clienteID", clienteID);
                cmd.Parameters.AddWithValue("@funcionarioID", funcionarioID);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                Conexao.Fechar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e);
            }
            Conexao.Fechar();
            return false;
        }
        public static bool DeleteVendas(int id)
        {
            Conexao.Conectar();

            string sql = "DELETE FROM vendas.dados WHERE id = " + id + ";";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                cmd.ExecuteNonQuery();

                Conexao.Fechar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e);
            }
            Conexao.Fechar();
            return false;
        }
        public static object DataGridView(DataGridView vendasDGV)
        {
            Conexao.Conectar();

            string sql = "SELECT * FROM vendas.dados";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, Conexao.conn);
                SqlDataAdapter sda = new SqlDataAdapter(sql, Conexao.conn);
                var ds = new DataSet();
                sda.Fill(ds);

                vendasDGV.DataSource = ds.Tables[0];

                Conexao.Fechar();
                return vendasDGV;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e);
                return null;
            }
        }
    }
}