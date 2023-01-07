using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.ContatoAtendimentoDto;
using CrmApi.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Services
{
    public class ContatoAtendimentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ContatoAtendimentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadContatoAtendimentoDto CriarContatoAtendimento(CreateContatoAtendimentoDto contatoAtendimentoDto)
        {
            ContatoAtendimento contatoAtendimento = _mapper.Map<ContatoAtendimento>(contatoAtendimentoDto);
            _context.ContatoAtendimentos.Add(contatoAtendimento);
            _context.SaveChanges();
            ReadContatoAtendimentoDto readDto = _mapper.Map<ReadContatoAtendimentoDto>(contatoAtendimento);
            return readDto;
        }

        public List<ReadContatoAtendimentoDto> RecuperarContatosAtendimentos()
        {
            List<ReadContatoAtendimentoDto> readDtos = _mapper.Map<List<ReadContatoAtendimentoDto>>(
                _context.ContatoAtendimentos);
            return readDtos;
        }

        public ReadContatoAtendimentoDto RecuperarContatoAtendimentoPorId(int id)
        {
            ContatoAtendimento contatoAtendimento = _context.ContatoAtendimentos.FirstOrDefault(
                contatoAtendimento => contatoAtendimento.Id == id);
            if (contatoAtendimento == null)
            {
                return null;
            }
            ReadContatoAtendimentoDto readDto = _mapper.Map<ReadContatoAtendimentoDto>(contatoAtendimento);
            return readDto;
        }

        public Result EditarContatoAtendimento(int id, UpdateContatoAtendimentoDto contatoAtendimentoDto)
        {
            ContatoAtendimento contatoAtendimento = _context.ContatoAtendimentos.FirstOrDefault(
                contatoAtendimento => contatoAtendimento.Id == id);
            if (contatoAtendimento == null)
            {
                return Result.Fail("ContatoAtendimento não encontrado");
            }
            _mapper.Map(contatoAtendimentoDto, contatoAtendimento);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
