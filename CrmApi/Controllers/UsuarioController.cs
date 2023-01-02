using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.UsuarioDto;
using CrmApi.Models;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] CreateUsuarioDto usuarioDto)
        {
            ReadUsuarioDto readDto = _service.CriarUsuario(usuarioDto);
            return CreatedAtAction(nameof(RecuperarUsuarioPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarUsuarios()
        {
            List<ReadUsuarioDto> usuariosDto = _service.RecuperarUsuarios();
            return Ok(usuariosDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarUsuarioPorId(int id)
        {
            ReadUsuarioDto usuarioDto = _service.RecuperarUsuarioPorId(id);
            if (usuarioDto == null) return NotFound();
            return Ok(usuarioDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarUsuario(int id, [FromBody] UpdateUsuarioDto usuarioDto)
        {
            Result resultado = _service.EditarUsuario(id, usuarioDto);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            Result resultado = _service.DeletarUsuario(id);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
