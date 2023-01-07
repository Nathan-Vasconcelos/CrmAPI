using CrmApi.Data.ContatoAtendimentoDto;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContatoAtendimentoController : ControllerBase
    {
        private ContatoAtendimentoService _service;

        public ContatoAtendimentoController(ContatoAtendimentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarContatoAtendimento([FromBody] CreateContatoAtendimentoDto contatoAtendimentoDto)
        {
            ReadContatoAtendimentoDto readDto = _service.CriarContatoAtendimento(contatoAtendimentoDto);
            return CreatedAtAction(nameof(RecuperarContatoAtendimentoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarContatosAtendimentos()
        {
            List<ReadContatoAtendimentoDto> readDtos = _service.RecuperarContatosAtendimentos();
            return Ok(readDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarContatoAtendimentoPorId(int id)
        {
            ReadContatoAtendimentoDto readDto = _service.RecuperarContatoAtendimentoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarContatoAtendimento(int id, [FromBody] UpdateContatoAtendimentoDto contatoAtendimentoDto)
        {
            Result resultado = _service.EditarContatoAtendimento(id, contatoAtendimentoDto);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
