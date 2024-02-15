using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Produtos
    {
        public int idProduto { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public string Unidade { get; set; }
        public double Preco { get; set; }
        public List<Historicos> Historico { get; set; } = new List<Historicos>();

        public void Atualizar(Produtos produto)
        {
            this.Descricao = produto.Descricao;
            this.Estoque = produto.Estoque;
            this.EstoqueMinimo = produto.EstoqueMinimo;
            this.Unidade = produto.Unidade;
            this.Preco = produto.Preco;
        }
        public void AtualizarPreco(double preco)
        {
            this.Historico.Add(new Historicos
            {
                IdProduto = this.idProduto,
                Preco = preco

            });
            this.Preco = preco;
        }
        public void VerificarEstoque()
        {
            if (this.Estoque <= this.EstoqueMinimo)
            {
                throw new Exception("O estoque mínimo deve ser "+this.EstoqueMinimo);
            }
           
        }

    }
}
