using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Models
{
    public class Atendimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual List<Parecer> Pareceres { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        [JsonIgnore]
        public virtual TipoAtendimento TipoAtendimento { get; set; }
        public int TipoAtendimentoId { get; set; }
    }
}
