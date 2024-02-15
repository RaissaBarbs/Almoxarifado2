namespace Almoxarifado_API.Models
{
    public class Departamentos
    {
        public int idDep { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public int idFunc { get; set; }
        public int idCargo { get; set; }
        public void Atualizar(Departamentos departamento)
        {
            this.Descricao = departamento.Descricao;
            this.Responsavel = departamento.Responsavel;
            this.idFunc = departamento.idFunc;
            this.idCargo = departamento.idCargo;
        }
        public List<Funcionarios> Funcionarios { get; set; } = new List<Funcionarios>();
        public Funcionarios BuscarFuncionario(string nome)
        {
            var Funcionario = this.Funcionarios.FirstOrDefault(x => x.FuncNome == nome);
            if (Funcionario == null)
            {
                throw new Exception("Funcionário não encontrado");

            }
            return Funcionario;
        }
    }
}
