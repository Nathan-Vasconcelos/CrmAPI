using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Models
{
    public class ContatoAtendimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual List<Parecer> Pareceres { get; set; }
    }
}
