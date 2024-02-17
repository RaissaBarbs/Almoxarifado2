using Almoxarifado_API.Metodos;
using Almoxarifado_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almoxarifado_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private CrudProdutos _crudProdutos;
        public ProdutosController(CrudProdutos crudProdutos)
        {
            _crudProdutos = crudProdutos;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public List<Produtos> Get()
        {
            return _crudProdutos.Listar();
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public Produtos? Get(int id)
        {
            return _crudProdutos.Buscar(id);
        }

        [HttpGet("fazerPedido/{id}/{quantidade}")]
        public IActionResult FazerPedido(int id, int quantidade)
        {
            try
            {
                var produto = _crudProdutos.Buscar(id);
                produto?.VerificarQuantidade(quantidade);
                return Ok("Pedido realizado");
            }
            catch (Exception ex)
            {

              return BadRequest(ex.Message);
            }
            
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult Post([FromBody] Produtos value)
        { 
  
            try
            {
                value.VerificarEstoqueMaiorQueMinimo();
                value.VerificarPreco();
                
                _crudProdutos.Adicionar(value);
                return Ok(_crudProdutos.Listar());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produtos value)
        {
            try
            {
                var produto = _crudProdutos.Buscar(id);
                produto?.Atualizar(value);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _crudProdutos.Deletar(id);
                return Ok("deletado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("Historico/{id}")]
        public List<Historicos> BuscarHistorico(int id)
        {
            return _crudProdutos.BuscarHistorico(id);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("AtualizarPreco/{id}")]
        public IActionResult AtualizarPreco(int id, double preco)
        {
            bool resultado = _crudProdutos.AtualizarPreco(id, preco);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
