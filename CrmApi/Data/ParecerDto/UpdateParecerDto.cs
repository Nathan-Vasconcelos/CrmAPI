using CrmApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrmApi.Data.ParecerDto
{
    public class UpdateParecerDto
    {
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo AtendimentoId é obrigatório")]
        public int AtendimentoId { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public ContatoAtendimento ContatoAtendimento { get; set; }
        public int ContatoAtendimentoId { get; set; }
    }
}
