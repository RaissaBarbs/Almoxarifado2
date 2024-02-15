using Almoxarifado_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almoxarifado_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private List<Categorias> _categorias;
        public CategoriasController(List<Categorias> categorias)
        {
            _categorias = categorias;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public List<Categorias> Get()
        {
            return _categorias;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public Categorias? Get(int id)
        {

            var categoria = _categorias.FirstOrDefault(x => x.idCategoria.Equals(id));
            return categoria;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult Post([FromBody] Categorias value)
        {
            try
            {
                _categorias.Add(value);
                return Ok(this.Get());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categorias value)
        {
            try
            {
                var categoria = this.Get(id);
                categoria?.Atualizar(value);
                return Ok(categoria);
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
                var categoria = this.Get(id);
                if (categoria != null)
                {
                    _categorias.Remove(categoria);
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
