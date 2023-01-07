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

        public List<ReadAtendimentoDto> RecuperarAtendimentos(int? statusAtendimento)
        {
            List<Atendimento> atendimentos;
            if (statusAtendimento == null)
            {
                atendimentos = _context.Atendimentos.ToList();
            }
            else
            {
                atendimentos = _context.Atendimentos.Where(
                    atendimento => atendimento.StatusAtendimentoId == statusAtendimento).ToList();
            }
            List<ReadAtendimentoDto> readDtos = _mapper.Map<List<ReadAtendimentoDto>>(atendimentos);
            return readDtos;
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

        public Result EditarAtendimento(int id, UpdateAtendimentoDto atendimentoDto)
        {
            Atendimento atendimento = _context.Atendimentos.FirstOrDefault(atendimento => atendimento.Id == id);
            if (atendimento == null)
            {
                return Result.Fail("Atendimento não encontrado");
            }
            _mapper.Map(atendimentoDto, atendimento);
            _context.SaveChanges();
            return Result.Ok();
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
