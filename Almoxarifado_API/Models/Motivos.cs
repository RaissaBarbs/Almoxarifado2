namespace Almoxarifado_API.Models
{
    public class Motivos
    {
        public int idMotivo { get; set; }
        public string Descricao { get; set; }
        public int idCategoria { get; set; }
        public void Atualizar(Motivos motivo)
        {
            this.Descricao = motivo.Descricao;
            this.idCategoria = motivo.idCategoria;
        }
    }
}
