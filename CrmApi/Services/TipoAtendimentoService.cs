using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.TipoAtendimentoDto;
using CrmApi.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Services
{
    public class TipoAtendimentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TipoAtendimentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadTipoAtendimentoDto CriarTipoAtendimento(CreateTipoAtendimentoDto tipoAtendimentoDto)
        {
            TipoAtendimento tipoAtendimento = _mapper.Map<TipoAtendimento>(tipoAtendimentoDto);
            _context.TipoAtendimentos.Add(tipoAtendimento);
            _context.SaveChanges();
            ReadTipoAtendimentoDto readDto = _mapper.Map<ReadTipoAtendimentoDto>(tipoAtendimento);
            return readDto;
        }

        public List<ReadTipoAtendimentoDto> RecuperarTiposAtendimentos()
        {
            List<ReadTipoAtendimentoDto> readDtos = _mapper.Map<List<ReadTipoAtendimentoDto>>(_context.TipoAtendimentos.ToList());
            return readDtos;
        }

        public ReadTipoAtendimentoDto RecuperarTipoAtendimentoPorId(int id)
        {
            TipoAtendimento tipoAtendimento = _context.TipoAtendimentos.FirstOrDefault(
                tipoAtendimento => tipoAtendimento.Id == id);
            if (tipoAtendimento == null)
            {
                return null;
            }
            ReadTipoAtendimentoDto readDto = _mapper.Map<ReadTipoAtendimentoDto>(tipoAtendimento);
            return readDto;
        }

        public Result EditarTipoAtendimento(int id, UpdateTipoAtendimentoDto tipoAtendimentoDto)
        {
            TipoAtendimento tipoAtendimento = _context.TipoAtendimentos.FirstOrDefault(
                tipoAtendimento => tipoAtendimento.Id == id);
            if (tipoAtendimento == null)
            {
                return Result.Fail("TipoAtendimento não encontrado");
            }
            _mapper.Map(tipoAtendimentoDto, tipoAtendimento);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
