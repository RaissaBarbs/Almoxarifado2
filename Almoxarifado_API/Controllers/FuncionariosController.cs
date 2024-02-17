using Almoxarifado_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almoxarifado_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private List<Funcionarios> _funcionarios;
        private List<Departamentos> _departamentos;
        public FuncionariosController(List<Funcionarios> funcionarios, List<Departamentos> departamentos)
        {
            _funcionarios = funcionarios;
            _departamentos = departamentos;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public List<Funcionarios> Get()
        {
            return _funcionarios;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public Funcionarios? Get(int id)
        {

            var funcionario = _funcionarios.FirstOrDefault(x => x.idFuncionario.Equals(id));
            return funcionario;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public IActionResult Post([FromBody] Funcionarios value)
        {
            try
            {
                value.VerificarSeTemDepartamento();
                value.VerificarSeDepartamentoExiste(_departamentos);
                _funcionarios.Add(value);
                return Ok(this.Get());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Funcionarios value)
        {
            try
            {
                var funcionario = this.Get(id);
                funcionario?.Atualizar(value);
                return Ok(funcionario);
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
                var funcionario = this.Get(id);
                if (funcionario != null)
                {
                    _funcionarios.Remove(funcionario);
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
