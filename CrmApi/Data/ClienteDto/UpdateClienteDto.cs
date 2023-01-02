using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.ClienteDto
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = "O campo RazaoSocial é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo RazaoSocial pode ter no máximo 200 caracteres")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "O campo NomeFantasia é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo NomeFantasia pode ter no máximo 200 caracteres")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "O campo Cnpj é obrigatório")]
        [MaxLength(18, ErrorMessage = "O campo Cnpj pode ter no máximo 18 caracteres")]
        public string Cnpj { get; set; }
    }
}
