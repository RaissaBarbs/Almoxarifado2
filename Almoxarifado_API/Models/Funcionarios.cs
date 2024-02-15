namespace Almoxarifado_API.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        public string FuncNome { get; set; }
        public Cargos Cargo { get; set; } = new Cargos();
        public string PegarCargo()
        {
            return this.Cargo.CargosNome;
        }
    }
}
