using CrmApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Data.ClienteDto
{
    public class ReadClienteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo RazaoSocial é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo RazaoSocial pode ter no máximo 200 caracteres")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "O campo NomeFantasia é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo NomeFantasia pode ter no máximo 200 caracteres")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "O campo Cnpj é obrigatório")]
        [MaxLength(18, ErrorMessage = "O campo Cnpj pode ter no máximo 18 caracteres")]
        public string Cnpj { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
        public List<Contrato> Contratos { get; set; }
    }
}
