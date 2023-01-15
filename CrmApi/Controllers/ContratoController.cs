using CrmApi.Data.ContratoDto;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContratoController : ControllerBase
    {
        private ContratoService _service;

        public ContratoController(ContratoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarContrato([FromBody] CreateContratoDto contratoDto)
        {
            ReadContratoDto readDto = _service.CriarContrato(contratoDto);
            return CreatedAtAction(nameof(RecuperarContratoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarContratos()
        {
            List<ReadContratoDto> readDtos = _service.RecuperarContratos();
            return Ok(readDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarContratoPorId(int id)
        {
            ReadContratoDto readDto = _service.RecuperarContratoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarContrato(int id, [FromBody] UpdateContratoDto contratoDto)
        {
            Result resultado = _service.EditarContrato(id, contratoDto);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
