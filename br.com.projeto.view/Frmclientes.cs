using Projeto_Vendas_Fatec_2.br.com.projeto.dao;
using Projeto_Vendas_Fatec_2.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Vendas_Fatec_2.br.com.projeto.view
{
    public partial class Frmclientes : Form
    {
        public Frmclientes()
        {
            InitializeComponent();
        }

     

        private void Frmclientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            dgclientes.DataSource = dao.ListarTodosClientes();

        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.nome = txtnome.Text;
            cliente.rg = txtrg.Text;
            cliente.cpf = txtcpf.Text;
            cliente.email = txtemail.Text;
            cliente.telefone = txttelefone.Text;
            cliente.celular = txtcelular.Text;
            cliente.cep = txtcep.Text;
            cliente.endereco= txtendereco.Text;
            cliente.numero = int.Parse(txtnumero.Text);
            cliente.complemento = txtcomp.Text;
            cliente.bairro = txtbairro.Text;
            cliente.cidade = txtcidade.Text;
            cliente.uf = cbuf.Text;

            ClienteDAO dao = new ClienteDAO();
            dao.CadastrarCliente(cliente);

            dgclientes.DataSource = dao.ListarTodosClientes();

        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //1 PASSO RECEBER OS DADOS EM UM OBJETO MODEL DE CLIENTE
            Cliente cliente = new Cliente();
            cliente.nome = txtnome.Text;
            cliente.rg = txtrg.Text;
            cliente.cpf = txtcpf.Text;
            cliente.email = txtemail.Text;
            cliente.telefone = txttelefone.Text;
            cliente.celular = txtcelular.Text;
            cliente.cep = txtcep.Text;
            cliente.endereco = txtendereco.Text;
            cliente.numero = int.Parse(txtnumero.Text);
            cliente.complemento = txtcomp.Text;
            cliente.bairro = txtbairro.Text;
            cliente.cidade = txtcidade.Text;
            cliente.uf = cbuf.Text;

            //RECEBER O ID DO CLIENTE
            cliente.id = int.Parse(txtcodigo.Text);

            //2 PASSO 
            ClienteDAO dao = new ClienteDAO();
            dao.AlterarCliente(cliente);

            //RECARREAGAR DATAGRID
            dgclientes.DataSource = dao.ListarTodosClientes();
        }

        private void dgclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //PEGANDO OS DADOS DE LINHA SELECIONADAS
            txtcodigo.Text     = dgclientes.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text       = dgclientes.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text         = dgclientes.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text        = dgclientes.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text      = dgclientes.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text   = dgclientes.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text    = dgclientes.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text        = dgclientes.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text   = dgclientes.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text     = dgclientes.CurrentRow.Cells[9].Value.ToString();
            txtcomp.Text       = dgclientes.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text     = dgclientes.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text     = dgclientes.CurrentRow.Cells[12].Value.ToString();
            cbuf.Text          = dgclientes.CurrentRow.Cells[13].Value.ToString();

            //ALTERANDO PARA GUIA DE DADOS PESSOAIS
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //BOTAO EXCLUIR
            ClienteDAO dao = new ClienteDAO();
            dao.ExcluirCliente(int.Parse(txtcodigo.Text));

            //RECARREGAR O DATAGRIDVIEW
            dgclientes.DataSource = dao.ListarTodosClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //1 PASSO -RECEBER O CEP
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                //EXIBIR DADOS NO CAMPO DE TEXTO
                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtcomp.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Endereço não encontrado,por favor digite manualmente.");
                
            }
        }

        private void cbfiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            //BOTAO CONSULTAR CLIENTE
            string dados = txtconsulta.Text;
            ClienteDAO dao = new ClienteDAO();

            //VERIFICAR QUAL É A OPÇÃO ESCOLHIDA NO COMBOBOX FILTRO
            if(cbfiltro.SelectedIndex == 0)
            {
                MessageBox.Show("Consulta por nome");
                dgclientes.DataSource = dao.ConsultarClientePorNome(dados);
               
                
            }
            else if(cbfiltro.SelectedIndex == 1)
            {
                MessageBox.Show("Consulta por CPF");
                dgclientes.DataSource = dao.ConsultarClientePorCPF(dados);

               
            }
            if (dgclientes.Rows.Count == 1)
            {
                MessageBox.Show("Cliente não encontrado!");
                dgclientes.DataSource = dao.ListarTodosClientes();
            }

        }
    }
}
