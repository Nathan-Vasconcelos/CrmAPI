using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Models
{
    public class Contrato
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo ProdutoId é obrigatório")]
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
        [Required(ErrorMessage = "O campo ClienteId é obrigatório")]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public double Valor { get; set; }
    }
}
