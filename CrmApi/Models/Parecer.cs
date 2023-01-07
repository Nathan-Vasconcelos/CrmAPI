using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Models
{
    public class Parecer
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }
        [JsonIgnore]
        public virtual Atendimento Atendimento { get; set; }
        public int AtendimentoId { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual ContatoAtendimento ContatoAtendimento { get; set; }
        public int ContatoAtendimentoId { get; set; }
    }
}
