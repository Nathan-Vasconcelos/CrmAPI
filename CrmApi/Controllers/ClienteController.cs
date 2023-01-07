using CrmApi.Data.ClienteDto;
using CrmApi.Models;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : ControllerBase
    {
        private ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarCLiente([FromBody] CreateClienteDto clienteDto)
        {
            ReadClienteDto readDto = _service.CriarCLiente(clienteDto);
            if (readDto == null) return BadRequest("O campo Cnpj é inválido ou já existante");
            return CreatedAtAction(nameof(RecuperarClientePorId), new { Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarClientes()
        {
            List<ReadClienteDto> clienteDtos = _service.RecuperarClientes();
            return Ok(clienteDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarClientePorId(int id)
        {
            ReadClienteDto clienteDto = _service.RecuperarClientePorId(id);
            if (clienteDto == null) return NotFound();
            return Ok(clienteDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarCLiente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            Result resultado = _service.EditarCLiente(id, clienteDto);
            if (resultado == null) return BadRequest("O campo Cnpj é inválido ou já existante");
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            Result resultado = _service.DeletarCliente(id);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
