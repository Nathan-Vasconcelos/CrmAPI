using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.ProdutoDto
{
    public class UpdateProdutoDto
    {
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Descricao pode ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public double Valor { get; set; }
    }
}
