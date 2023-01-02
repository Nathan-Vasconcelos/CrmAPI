using CrmApi.Data.ParecerDto;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ParecerController : ControllerBase
    {
        private ParecerService _service;
        public ParecerController(ParecerService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarParecer(CreateParecerDto parecerDto)
        {
            ReadParecerDto readDto = _service.CriarParecer(parecerDto);
            return Ok();
        }

        [HttpGet]
        public IActionResult RecuperarPareceres()
        {
            List<ReadParecerDto> readDtos = _service.RecuperarPareceres();
            return Ok(readDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarParecerPorId(int id)
        {
            ReadParecerDto readDto = _service.RecuperarParecerPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarParecer(int id)
        {
            Result resultado = _service.DeletarParecer(id);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
