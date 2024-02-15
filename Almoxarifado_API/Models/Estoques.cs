namespace Almoxarifado_API.Models
{
    public class Estoques
    {
        public int IdEstoque { get; set; }
        public string Descricao { get; set; }
        public int Estoque => this.Produtos.Count;
        public int EstoqueMinimo { get; set; }
        public List<Produtos> Produtos { get; set; } = new List<Produtos>();
        public void Atualizar(Estoques estoque)
        {
            this.Descricao = estoque.Descricao;
            this.EstoqueMinimo = estoque.EstoqueMinimo;
        }
        public void AdicionarProduto(Produtos produto)
        {
            this.Produtos.Add(produto);
        }
        public List<Produtos> MostrarProdutos() 
        {
            return this.Produtos; 
        }
        public int EstoqueTotal()
        {
            return this.Produtos.Sum(x => x.Estoque);
        }
    }
}
