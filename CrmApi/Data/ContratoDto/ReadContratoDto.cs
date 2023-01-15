using CrmApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.ContratoDto
{
    public class ReadContratoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo ProdutoId é obrigatório")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        [Required(ErrorMessage = "O campo ClienteId é obrigatório")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public double Acrescimo { get; set; }
    }
}
