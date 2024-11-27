using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CadastroDeProdutos
{
    public partial class Form1 : Form
    {
        private List<Produto> produtos = new List<Produto>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto
                {
                    ID = int.Parse(txtID.Text),
                    Nome = txtNome.Text,
                    Preco = decimal.Parse(txtPreco.Text),
                    Categoria = txtCategoria.Text,
                    Quantidade = int.Parse(txtQuantidade.Text)
                };
                produtos.Add(produto);
                MessageBox.Show("Produto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = produtos;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                Produto produto = produtos.FirstOrDefault(p => p.ID == id);
                if (produto != null)
                {
                    produto.Nome = txtNome.Text;
                    produto.Preco = decimal.Parse(txtPreco.Text);
                    produto.Categoria = txtCategoria.Text;
                    produto.Quantidade = int.Parse(txtQuantidade.Text);
                    MessageBox.Show("Produto atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                Produto produto = produtos.FirstOrDefault(p => p.ID == id);
                if (produto != null)
                {
                    produtos.Remove(produto);
                    MessageBox.Show("Produto excluído com sucesso!");
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }

    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
    }
}
