using CrmApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrmApi.Data.AtendimentoDto
{
    public class ReadAtendimentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public List<Parecer> Pareceres { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public int TipoAtendimentoId { get; set; }
    }
}
