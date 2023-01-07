using CrmApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.StatusAtendimentoDto
{
    public class ReadStatusAtendimentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 15 caracteres")]
        public string Descricao { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
    }
}
