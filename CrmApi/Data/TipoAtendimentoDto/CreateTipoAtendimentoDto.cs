using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.TipoAtendimentoDto
{
    public class CreateTipoAtendimentoDto
    {
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Descricao pode ter no máximo 100 caracteres")]
        public string Descricao { get; set; }
    }
}
