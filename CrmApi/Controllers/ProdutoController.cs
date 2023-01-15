using CrmApi.Data.ProdutoDto;
using CrmApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace CrmApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : ControllerBase
    {
        private ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriarProduto([FromBody] CreateProdutoDto produtoDto)
        {
            ReadProdutoDto readDto = _service.CriarProduto(produtoDto);
            if (readDto == null) return BadRequest();
            return CreatedAtAction(nameof(RecuperarProdutoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarProdutos()
        {
            List<ReadProdutoDto> readDtos = _service.RecuperarProdutos();
            return Ok(readDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarProdutoPorId(int id)
        {
            ReadProdutoDto readDto = _service.RecuperarProdutoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditarProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            Result resultado = _service.EditarProduto(id, produtoDto);
            if (resultado.IsFailed) return NotFound(resultado.Errors[0].Message);
            return NoContent();
        }
    }
}
