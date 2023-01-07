using CrmApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.ContatoAtendimentoDto
{
    public class ReadContatoAtendimentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
        public List<Parecer> Pareceres { get; set; }
    }
}
