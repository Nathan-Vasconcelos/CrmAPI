using CrmApi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Data.ParecerDto
{
    public class ReadParecerDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }
        [JsonIgnore]
        public Atendimento Atendimento { get; set; }
        [Required(ErrorMessage = "O campo AtendimentoId é obrigatório")]
        public int AtendimentoId { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
