using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.ContatoAtendimentoDto
{
    public class CreateContatoAtendimentoDto
    {
        [Required(ErrorMessage = "O campo Descricao")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
    }
}
