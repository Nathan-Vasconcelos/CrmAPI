using CrmApi.Data.AtendimentoDto;
using CrmApi.Models;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AtendimentoController : ControllerBase
    {
        private AtendimentoService _service;

        public AtendimentoController(AtendimentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarAtendimento([FromBody] CreateAtendimentoDto atendimentoDto)
        {
            ReadAtendimentoDto readDto = _service.CriarAtendimento(atendimentoDto);
            return CreatedAtAction(nameof(RecuperarAtendimentoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarAtendimentos([FromQuery] int? statusAtendimento = null)
        {
            List<ReadAtendimentoDto> atendimentos = _service.RecuperarAtendimentos(statusAtendimento);
            if (atendimentos == null) return NotFound();
            return Ok(atendimentos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarAtendimentoPorId(int id)
        {
            ReadAtendimentoDto readDto = _service.RecuperarAtendimentoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarAtendimento(int id, [FromBody] UpdateAtendimentoDto atendimentoDto)
        {
            Result resultado = _service.EditarAtendimento(id, atendimentoDto);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarAtendimento(int id)
        {
            Result resultado = _service.DeletarAtendimento(id);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
