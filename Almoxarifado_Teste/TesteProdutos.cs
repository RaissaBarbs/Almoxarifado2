using Almoxarifado_API.Metodos;
using Almoxarifado_API.Models;

namespace Almoxarifado_Teste
{
    [TestClass]
    public class TesteProdutos
    {
        private readonly CrudProdutos _crud;
        public TesteProdutos()
        {
            _crud = new CrudProdutos();
        }
        [TestMethod]
        public void ErroEstoqueMenorQueMinimo()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                var produto = new Produtos
                {
                    Descricao = "tomate",
                    EstoqueMinimo = 10,
                    Estoque = 5
                };
                produto.VerificarEstoqueMaiorQueMinimo();
                _crud.Adicionar(produto);
            });
        }
        [TestMethod]
        public void EstoqueMaiorQueMinimo()
        {
            var produto = new Produtos
            {
                Descricao = "tomate",
                EstoqueMinimo = 10,
                Estoque = 15
            };
            produto.VerificarEstoqueMaiorQueMinimo();
            _crud.Adicionar(produto);
        }
        [TestMethod]
        public void AlterarPreco()
        {
            int esperado = 3;
            var produto = new Produtos
            {
                Descricao = "cebola",
                Preco = 7

            };
            produto.AtualizarPreco(3);
            Assert.AreEqual(esperado, produto.Preco);
        }
        [TestMethod]
        public void HistoricoDePrecos()
        {
            int resultado = 5;
            var produto = new Produtos
            {
                Descricao = "cebola",
                Preco = 7

            };
            produto.AtualizarPreco(3);
            produto.AtualizarPreco(2);
            produto.AtualizarPreco(1);
            produto.AtualizarPreco(5);
            produto.AtualizarPreco(6);
            Assert.AreEqual(resultado, produto.Historico.Count);
        }
        [TestMethod]
        public void ErroQuantidadeMenorQueMinima()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                int pedido = 3;
                var produto = new Produtos
                {
                    Descricao = "tomate",
                    QuantidadeMinima = 5
                };
                produto.VerificarQuantidade(pedido);
                _crud.Adicionar(produto);
            });
        }
        [TestMethod]
        public void InserirProduto()
        {
            int pedido = 10;
            var produto = new Produtos
            {
                Descricao = "tomate",
                QuantidadeMinima = 5,
                Preco = 10
            };
            produto.VerificarQuantidade(pedido);
            produto.VerificarPreco();
            _crud.Adicionar(produto);
        }

        [TestMethod]
        public void ErroPrecoMenorQue0()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                var produto = new Produtos
                {
                    Descricao = "arroz",
                    Preco = -2
                };
                produto.VerificarPreco();
                _crud.Adicionar(produto);
            });
        }
    }
}