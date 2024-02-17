namespace Almoxarifado_API.Models
{
    public class Funcionarios
    {
        public int idFuncionario { get; set; }
        public string FuncNome { get; set; }
        public Cargos Cargo { get; set; } = new Cargos();
        public int idDepartamento { get; set; }
        public string PegarCargo()
        {
            return this.Cargo.CargosNome;
        }
        public void Atualizar(Funcionarios funcionarios)
        {
            this.FuncNome = funcionarios.FuncNome;
            this.Cargo = funcionarios.Cargo;
            this.idDepartamento = funcionarios.idDepartamento;
        }
        public void VerificarSeDepartamentoExiste(List<Departamentos> departamentos)
        {
            if (departamentos.Any(x => x.idDep == this.idDepartamento))
            {
                
            }
            else
            {
                throw new Exception("Coloque um departamento que existe no sistema");
            }
        }
        public void VerificarSeTemDepartamento()
        {
            if(this.idDepartamento == 0)
            {
                throw new Exception("O departamento é obrigatório.");
            }
        }
    }
}
