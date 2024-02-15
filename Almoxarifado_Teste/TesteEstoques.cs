using Almoxarifado_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado_Teste
{
    [TestClass]
    public class TesteEstoques

    {
        [TestMethod]
        public void SomaEstoquesTodosProdutos()
        {
            int esperado = 35;
            var estoque = new Estoques
            {
                Produtos = new List<Produtos>
                {
                    new Produtos {Estoque = 5},
                    new Produtos { Estoque = 6},
                    new Produtos { Estoque = 7},
                    new Produtos { Estoque = 8},
                    new Produtos { Estoque = 9}
                }
            };
            Assert.AreEqual(esperado, estoque.EstoqueTotal());
        }
    }
}
