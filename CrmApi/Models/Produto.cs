using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public double Valor { get; set; }
        [JsonIgnore]
        public virtual List<Contrato> Contratos { get; set; }
    }
}
