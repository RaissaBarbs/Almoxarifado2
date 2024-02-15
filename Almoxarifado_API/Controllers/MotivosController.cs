using Almoxarifado_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almoxarifado_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivosController : ControllerBase
    {
        private List<Motivos> _motivos;
        public MotivosController(List<Motivos> motivos)
        {
            _motivos = motivos;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public List<Motivos> Get()
        {
            return _motivos;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public Motivos? Get(int id)
        {

            var motivo = _motivos.FirstOrDefault(x => x.idMotivo.Equals(id));
            return motivo;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult Post([FromBody] Motivos value)
        {
            try
            {
                _motivos.Add(value);
                return Ok(this.Get());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Motivos value)
        {
            try
            {
                var motivo = this.Get(id);
                motivo?.Atualizar(value);
                return Ok(motivo);
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
                var motivo = this.Get(id);
                if (motivo != null)
                {
                    _motivos.Remove(motivo);
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

