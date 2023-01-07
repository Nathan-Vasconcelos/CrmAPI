using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.StatusAtendimentoDto
{
    public class UpdateStatusAtendimentoDto
    {
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 15 caracteres")]
        public string Descricao { get; set; }
    }
}
