using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.StatusAtendimentoDto;
using CrmApi.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Services
{
    public class StatusAtendimentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public StatusAtendimentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadStatusAtendimentoDto CriarStatusAtendimento(CreateStatusAtendimentoDto statusAtendimentoDto)
        {
            StatusAtendimento statusAtendimento = _mapper.Map<StatusAtendimento>(statusAtendimentoDto);
            _context.StatusAtendimentos.Add(statusAtendimento);
            _context.SaveChanges();
            ReadStatusAtendimentoDto readDto = _mapper.Map<ReadStatusAtendimentoDto>(statusAtendimento);
            return readDto;
        }

        public List<ReadStatusAtendimentoDto> RecuperarStatusAtendimentos()
        {
            List<ReadStatusAtendimentoDto> readDtos = _mapper.Map<List<ReadStatusAtendimentoDto>>(_context.StatusAtendimentos.ToList());
            return readDtos;
        }

        public ReadStatusAtendimentoDto RecuperarStatusAtendimentoPorId(int id)
        {
            StatusAtendimento statusAtendimento = _context.StatusAtendimentos.FirstOrDefault(
                statusAtendimento => statusAtendimento.Id == id);
            if (statusAtendimento == null)
            {
                return null;
            }
            ReadStatusAtendimentoDto readDto = _mapper.Map<ReadStatusAtendimentoDto>(statusAtendimento);
            return readDto;
        }

        public Result EditarStatusAtendimento(int id, UpdateStatusAtendimentoDto statusAtendimentoDto)
        {
            StatusAtendimento statusAtendimento = _context.StatusAtendimentos.FirstOrDefault(
                statusAtendimento => statusAtendimento.Id == id);
            if (statusAtendimento == null)
            {
                return Result.Fail("StatusAtendimento não encontrado");
            }
            _mapper.Map(statusAtendimentoDto, statusAtendimento);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
