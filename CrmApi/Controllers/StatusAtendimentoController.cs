using CrmApi.Data.StatusAtendimentoDto;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StatusAtendimentoController : ControllerBase
    {
        private StatusAtendimentoService _service;

        public StatusAtendimentoController(StatusAtendimentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarStatusAtendimento([FromBody] CreateStatusAtendimentoDto statusAtendimentoDto)
        {
            ReadStatusAtendimentoDto readDto = _service.CriarStatusAtendimento(statusAtendimentoDto);
            return CreatedAtAction(nameof(RecuperarStatusAtendimentoPorId), new {Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarStatusAtendimentos()
        {
            List<ReadStatusAtendimentoDto> readDtos = _service.RecuperarStatusAtendimentos();
            return Ok(readDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarStatusAtendimentoPorId(int id)
        {
            ReadStatusAtendimentoDto readDto = _service.RecuperarStatusAtendimentoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarStatusAtendimento(int id, [FromBody] UpdateStatusAtendimentoDto statusAtendimentoDto)
        {
            Result resultado = _service.EditarStatusAtendimento(id, statusAtendimentoDto);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
