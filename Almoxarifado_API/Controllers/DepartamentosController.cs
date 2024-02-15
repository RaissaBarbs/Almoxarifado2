using Almoxarifado_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almoxarifado_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private List<Departamentos> _departamentos;
        public DepartamentosController(List<Departamentos> departamentos)
        {
            _departamentos = departamentos;

        }
        // GET: api/<CategoriasController>
        [HttpGet]
        public List<Departamentos> Get()
        {
            return _departamentos;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public Departamentos? Get(int id)
        {

            var departamento = _departamentos.FirstOrDefault(x => x.idDep.Equals(id));
            return departamento;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("buscarFuncionario/{id}/{nome}")]
        public IActionResult buscarFuncionario(int id, string nome)
        {
            try
            {
                var departamento = _departamentos.FirstOrDefault(x => x.idDep.Equals(id));
                return Ok( departamento.BuscarFuncionario(nome));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("buscarCargoPorFuncionario/{id}/{nome}")]
        public IActionResult buscarCargoPorFuncionario(int id, string nome)
        {
            try
            {
                var departamento = _departamentos.FirstOrDefault(x => x.idDep.Equals(id));
                var funcionario = departamento.BuscarFuncionario(nome);
                return Ok(funcionario.PegarCargo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult Post([FromBody] Departamentos value)
        {
            try
            {
                _departamentos.Add(value);
                return Ok(this.Get());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamentos value)
        {
            try
            {
                var departamento = this.Get(id);
                departamento?.Atualizar(value);
                return Ok(departamento);
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
                var departamento = this.Get(id);
                if (departamento != null)
                {
                    _departamentos.Remove(departamento);
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
