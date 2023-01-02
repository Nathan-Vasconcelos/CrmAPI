using CrmApi.Data.TipoAtendimentoDto;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TipoAtendimentoController : ControllerBase
    {
        private TipoAtendimentoService _service;

        public TipoAtendimentoController(TipoAtendimentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarTipoAtendimento(CreateTipoAtendimentoDto tipoAtendimentoDto)
        {
            ReadTipoAtendimentoDto readDto = _service.CriarTipoAtendimento(tipoAtendimentoDto);
            return CreatedAtAction(nameof(RecuperarTipoAtendimentoPorId), new {Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarTiposAtendimentos()
        {
            List<ReadTipoAtendimentoDto> readDtos = _service.RecuperarTiposAtendimentos();
            return Ok(readDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarTipoAtendimentoPorId(int id)
        {
            ReadTipoAtendimentoDto readDto = _service.RecuperarTipoAtendimentoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarTipoAtendimento(int id, UpdateTipoAtendimentoDto tipoAtendimentoDto)
        {
            Result resultado = _service.EditarTipoAtendimento(id, tipoAtendimentoDto);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
