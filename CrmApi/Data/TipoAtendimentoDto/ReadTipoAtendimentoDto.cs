using CrmApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.TipoAtendimentoDto
{
    public class ReadTipoAtendimentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Descricao pode ter no máximo 100 caracteres")]
        public string Descricao { get; set; }
        public virtual List<Atendimento> Atendimentos { get; set; }
    }
}
