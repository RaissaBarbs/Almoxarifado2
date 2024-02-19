using System.ComponentModel.DataAnnotations;

namespace Almoxarifado_API.Models
{
    public class Produtos
    {
        public int idProduto { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public double Preco { get; set; }
        public int QuantidadeMinima { get; set; }
        public List<Historicos> Historico { get; set; } = new List<Historicos>();

        public void Atualizar(Produtos produto)
        {
            this.Descricao = produto.Descricao;
            this.Estoque = produto.Estoque;
            this.EstoqueMinimo = produto.EstoqueMinimo;
            this.Preco = produto.Preco;
            this.QuantidadeMinima = produto.QuantidadeMinima;
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
        public void VerificarEstoqueMaiorQueMinimo()
        {
            if (this.Estoque > this.EstoqueMinimo)
            {
                
            }
            else
            {
                throw new Exception("O estoque mínimo deve ser " + this.EstoqueMinimo);
            }
        }

        public void VerificarQuantidade(int quantidade)
        {

            if (quantidade < this.QuantidadeMinima)
            {
                throw new Exception("A quantidade deve ser maior "+this.QuantidadeMinima);
            }
        }

        public void VerificarPreco()
        {
            if (Preco < 0)
            {
                throw new Exception("O preço deve ser maior que 0");
            }
        }

    }
   
}
