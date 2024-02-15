using Almoxarifado_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almoxarifado_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesController : ControllerBase
    {
        private List<Estoques> _estoques;
        public EstoquesController(List<Estoques> estoques)
        {
            _estoques = estoques;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public List<Estoques> Get()
        {
            return _estoques;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public Estoques? Get(int id)
        {

            var estoque = _estoques.FirstOrDefault(x => x.IdEstoque.Equals(id));
            return estoque;
        }

        [HttpGet("EstoqueTotal/{id}")]
        public int EstoqueTotal(int id)
        {

            var estoque = _estoques.FirstOrDefault(x => x.IdEstoque.Equals(id));
            return estoque.EstoqueTotal();
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult Post([FromBody] Estoques value)
        {
            try
            {
                _estoques.Add(value);
                return Ok(this.Get());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("adicionarProduto/{id}")]
        public IActionResult adicionarProduto( int id, [FromBody] Produtos value)
        {
            try
            {
               var estoque = _estoques.FirstOrDefault(x => x.IdEstoque == id );
                estoque?.AdicionarProduto(value);
                return Ok(this.Get());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estoques value)
        {
            try
            {
                var estoque = this.Get(id);
                estoque?.Atualizar(value);
                return Ok(estoque);
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
                var estoque = this.Get(id);
                if (estoque != null)
                {
                    _estoques.Remove(estoque);
                }
                return Ok("deletado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
