using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Data.Models
{
    [Table("Categoria_Prato")]
    public class CategoriaPrato
    {
        public int IdCategoriaPrato { get; set; }
        public string DescricaoCategoria { get; set; }
        public ICollection<Prato> Pratos { get; set; } = new List<Prato>();
    }
}
