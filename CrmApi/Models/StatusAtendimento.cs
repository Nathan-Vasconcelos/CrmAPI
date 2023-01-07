using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace CrmApi.Models
{
    public class StatusAtendimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 15 caracteres")]
        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual List<Atendimento> Atendimentos { get; set; }
    }
}
