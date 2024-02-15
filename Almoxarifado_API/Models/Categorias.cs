namespace Almoxarifado_API.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Categorias
    {
        public int idCategoria { get; set; }
        public string Descricao { get; set; }
        public void Atualizar(Categorias categoria)
        {
            this.Descricao = categoria.Descricao;
        }
    }

}
