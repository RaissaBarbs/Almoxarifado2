using Almoxarifado_API.Models;
using System.Xml.Linq;

namespace Almoxarifado_API.Metodos
{
    public class CrudProdutos
    {
        private List<Produtos> _produtos;

        public CrudProdutos()
        {
            _produtos = new List<Produtos>
            {
                new Produtos
                {
                    idProduto = 1,
                    Descricao = "vassoura",
                     Preco = 20,
                    Historico = new List<Historicos>
                    {
                        new Historicos
                        {
                            Preco = 22

                        },
                        new Historicos
                        {
                            Preco = 25
                        }
                    }
                },
                new Produtos
                {
                    Descricao = "martelo",
                    Preco = 20,
                    Historico = new List<Historicos>
                    {
                        new Historicos
                        {
                            Preco = 22

                        },
                        new Historicos
                        {
                            Preco = 25
                        }
                    }
                }, 
                new Produtos
                {
                    Descricao = "xicara", 
                    Preco = 12,
                    Historico = new List<Historicos>
                    { 
                        new Historicos
                        {
                            Preco = 14

                        },
                        new Historicos
                        {
                            Preco = 20
                        }
                    }
                }


            };
        }

        public List<Produtos> Listar()
        {
            return _produtos;
        }

        public Produtos? Buscar(int id)
        {
            var produto = _produtos.FirstOrDefault(x => x.idProduto.Equals(id));
            return produto;
        }

        public void Adicionar(Produtos value)
        {

            value.VerificarEstoque();
            _produtos.Add(value);

        }

        public bool Atualizar(int id, Produtos value)
        {
            try
            {
                var produto = this.Buscar(id);
                produto?.Atualizar(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AtualizarPreco(int id, double preco)
        {
            try
            {
                var produto = this.Buscar(id);
                produto?.AtualizarPreco(preco);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Deletar(int id)
        {
            try
            {
                var produto = this.Buscar(id);
                if (produto != null)
                {
                    _produtos.Remove(produto);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Historicos> BuscarHistorico(int id)
        {
            var produto = _produtos.FirstOrDefault(x => x.idProduto.Equals(id));
            return produto.Historico;
        }
    }

}
