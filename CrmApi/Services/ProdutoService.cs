using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.ProdutoDto;
using CrmApi.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Services
{
    public class ProdutoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ProdutoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadProdutoDto CriarProduto(CreateProdutoDto produtoDto)
        {
            bool resultado = ValidarValorProduto(produtoDto.Valor);
            if (!resultado)
            {
                return null;
            }
            Produto produto = _mapper.Map<Produto>(produtoDto);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            ReadProdutoDto readDto = _mapper.Map<ReadProdutoDto>(produto);
            return readDto;
        }

        public List<ReadProdutoDto> RecuperarProdutos()
        {
            List<ReadProdutoDto> readDtos = _mapper.Map<List<ReadProdutoDto>>(_context.Produtos);
            return readDtos;
        }

        public ReadProdutoDto RecuperarProdutoPorId(int id)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
            {
                return null;
            }
            ReadProdutoDto readDto = _mapper.Map<ReadProdutoDto>(produto);
            return readDto;
        }

        public Result EditarProduto(int id, UpdateProdutoDto produtoDto)
        {
            bool resultado = ValidarValorProduto(produtoDto.Valor);
            if (!resultado)
            {
                return Result.Fail("Valor do Produto inválido");
            }
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
            {
                return Result.Fail("Produto não encontrado");
            }
            _mapper.Map(produtoDto, produto);
            _context.SaveChanges();
            return Result.Ok();
        }

        public bool ValidarValorProduto(double valor)
        {
            if (valor <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
