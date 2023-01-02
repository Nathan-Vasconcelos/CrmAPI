using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        [MaxLength(14, ErrorMessage = "O campo Cpf pode ter no máximo 14 caracteres")]
        public string Cpf { get; set; }
        [JsonIgnore]
        public virtual List<Atendimento> Atendimentos { get; set; }

    }
}
