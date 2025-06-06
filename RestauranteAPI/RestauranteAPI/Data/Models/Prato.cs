using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestauranteAPI.Data.Models
{
    [Table("Prato")]
    public class Prato
    {
        public int IdPrato { get; set; }
        public string NomePrato { get; set; }
        public string? DescricaoPrato { get; set; }
        public int IdCategoriaPrato { get; set; }
        public decimal ValorPrato { get; set; }
        [JsonIgnore]
        public virtual CategoriaPrato? CategoriaPrato { get; set; }
    }
}
