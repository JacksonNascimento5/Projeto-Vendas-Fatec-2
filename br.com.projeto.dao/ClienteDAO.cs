using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Projeto_Vendas_Fatec_2.br.com.projeto.con;
using Projeto_Vendas_Fatec_2.br.com.projeto.model;

namespace Projeto_Vendas_Fatec_2.br.com.projeto.dao
{
    class ClienteDAO
    {
        private MySqlConnection conexao;

        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                //1 PASSO - CRIAR O COMANDO SQL
                string sql = @"insert into tb_clientes(nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado) 
                               values(@nome,@rg,@cpf,@email,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";

                //2 PASSO - ORGANIZAR O COMANDO SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", cliente.nome);
                executasql.Parameters.AddWithValue("@rg", cliente.rg);
                executasql.Parameters.AddWithValue("@cpf", cliente.cpf);
                executasql.Parameters.AddWithValue("@email", cliente.email);
                executasql.Parameters.AddWithValue("@telefone", cliente.telefone);
                executasql.Parameters.AddWithValue("@celular", cliente.celular);
                executasql.Parameters.AddWithValue("@cep", cliente.cep);
                executasql.Parameters.AddWithValue("@endereco", cliente.endereco);
                executasql.Parameters.AddWithValue("@numero", cliente.numero);
                executasql.Parameters.AddWithValue("@complemento", cliente.complemento);
                executasql.Parameters.AddWithValue("@bairro", cliente.bairro);
                executasql.Parameters.AddWithValue("@cidade", cliente.cidade);
                executasql.Parameters.AddWithValue("@estado", cliente.uf);


                //3 PASSO - ABRIR A CONEXAO E EXECUTAR O COMANDO SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso");

                conexao.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("aconteceu um erro" + erro);
            }
        }

        public void AlterarCliente(Cliente cliente)
        {
            try
            {
                string sql = @"update tb_clientes set
                               nome = @nome, rg = @rg, cpf = @cpf, 
                               email = @email, telefone = @telefone, 
                               celular = @celular, cep = @cep, endereco = @endereco, 
                               numero = @numero, complemento = @complemento, bairro = @bairro,
                               cidade = @cidade, estado = @estado where id = @id";

                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", cliente.nome);
                executasql.Parameters.AddWithValue("@rg", cliente.rg);
                executasql.Parameters.AddWithValue("@cpf", cliente.cpf);
                executasql.Parameters.AddWithValue("@email", cliente.email);
                executasql.Parameters.AddWithValue("@telefone", cliente.telefone);
                executasql.Parameters.AddWithValue("@celular", cliente.celular);
                executasql.Parameters.AddWithValue("@cep", cliente.cep);
                executasql.Parameters.AddWithValue("@endereco", cliente.endereco);
                executasql.Parameters.AddWithValue("@numero", cliente.numero);
                executasql.Parameters.AddWithValue("@complemento", cliente.complemento);
                executasql.Parameters.AddWithValue("@bairro", cliente.bairro);
                executasql.Parameters.AddWithValue("@cidade", cliente.cidade);
                executasql.Parameters.AddWithValue("@estado", cliente.uf);
                executasql.Parameters.AddWithValue("@id", cliente.id);

                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Cliente atualizado com sucesso");

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu erro: " + erro);
            }
        }

        public void ExcluirCliente(int idcliente)
        {
            try
            {
                string sql = @"delete from tb_clientes where id = @id";

                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@id", idcliente);

                conexao.Open();
                executasql.ExecuteNonQuery();

                MessageBox.Show("Cliente apagado com sucesso");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu um erro: " + erro);
            }
        }

        public DataTable ListarTodosClientes()
        {
            try
            {
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes";

                MySqlCommand executasql = new MySqlCommand(sql, conexao);

                conexao.Open();
                executasql.ExecuteNonQuery();

                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaCliente);

                return tabelaCliente;


            }
            catch (Exception erro)
            {

                MessageBox.Show("Deu erro: " + erro);
                return null;
            }
        }

        public DataTable ConsultarClientePorNome(string nome)
        {
            try
            {
                //1 PASSO - CRIAR O COMANDO SQL E O NOSSO DATABLE
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes where nome = @nome";

                //2 PASSO - ORGANIZAR E EXECURA O COMANDO SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@nome", nome);

                //3 PASSO - ABRIR A CONEXAO E EXECUTAR O COMANDO SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 PASSO - PREENCHER O NOSSO DATABLE COM OS DADOS DO SELECT
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaCliente);
                
                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Deu erro: " + erro);
                return null;
            }
        }
        public DataTable ConsultarClientePorCPF(string cpf)
        {
            try
            {
                //1 PASSO - CRIAR O COMANDO SQL E O NOSSO DATABLE
                DataTable tabelaCliente = new DataTable();
                string sql = @"select * from tb_clientes where cpf = @cpf";

                //2 PASSO - ORGANIZAR E EXECURA O COMANDO SQL
                MySqlCommand executasql = new MySqlCommand(sql, conexao);
                executasql.Parameters.AddWithValue("@cpf", cpf);

                //3 PASSO - ABRIR A CONEXAO E EXECUTAR O COMANDO SQL
                conexao.Open();
                executasql.ExecuteNonQuery();

                //4 PASSO - PREENCHER O NOSSO DATABLE COM OS DADOS DO SELECT
                MySqlDataAdapter adapter = new MySqlDataAdapter(executasql);
                adapter.Fill(tabelaCliente);

                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Deu erro: " + erro);
                return null;
            }
        }
    }
}
