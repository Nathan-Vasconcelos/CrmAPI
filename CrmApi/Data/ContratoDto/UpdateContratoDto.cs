using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.ContratoDto
{
    public class UpdateContratoDto
    {
        [MaxLength(50)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo ProdutoId é obrigatório")]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O campo ClienteId é obrigatório")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public double Valor { get; set; }
    }
}
