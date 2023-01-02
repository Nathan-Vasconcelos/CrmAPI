using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.AtendimentoDto
{
    public class UpdateAtendimentoDto
    {
        [Required(ErrorMessage = "O campo UsuarioId é obrigatório")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "O campo ClienteId é obrigatório")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "O campo TipoAtendimentoId é obrigatório")]
        public int TipoAtendimentoId { get; set; }
    }
}
