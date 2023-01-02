using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.AtendimentoDto;
using CrmApi.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Services
{
    public class AtendimentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AtendimentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAtendimentoDto CriarAtendimento([FromBody] CreateAtendimentoDto atendimentoDto)
        {
            Atendimento atendimento = _mapper.Map<Atendimento>(atendimentoDto);
            _context.Atendimentos.Add(atendimento);
            _context.SaveChanges();
            ReadAtendimentoDto readDto = _mapper.Map<ReadAtendimentoDto>(atendimento);
            return readDto;
        }

        public List<ReadAtendimentoDto> RecuperarAtendimentos()
        {
            List<ReadAtendimentoDto> atendimentos = _mapper.Map<List<ReadAtendimentoDto>>(_context.Atendimentos.ToList());
            return atendimentos;
        }

        public ReadAtendimentoDto RecuperarAtendimentoPorId(int id)
        {
            Atendimento atendimento = _context.Atendimentos.FirstOrDefault(atendimento => atendimento.Id == id);
            if (atendimento == null)
            {
                return null;
            }
            ReadAtendimentoDto readDto = _mapper.Map<ReadAtendimentoDto>(atendimento);
            return readDto;
        }

        public Result DeletarAtendimento(int id)
        {
            Atendimento atendimento = _context.Atendimentos.FirstOrDefault(atendimento => atendimento.Id == id);
            if (atendimento == null)
            {
                return Result.Fail("Atendimento não encontrado");
            }
            _context.Remove(atendimento);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
