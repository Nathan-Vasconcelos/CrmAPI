using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.UsuarioDto
{
    public class UpdateUsuarioDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        [MaxLength(14, ErrorMessage = "O campo Cpf pode ter no máximo 14 caracteres")]
        public string Cpf { get; set; }
    }
}
