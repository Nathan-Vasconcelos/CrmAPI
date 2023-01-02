using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.ParecerDto;
using CrmApi.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Services
{
    public class ParecerService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ParecerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadParecerDto CriarParecer(CreateParecerDto parecerDto)
        {
            Parecer parecer = _mapper.Map<Parecer>(parecerDto);
            parecer.DataAtualizacao = DateTime.Now;
            _context.Pareceres.Add(parecer);
            _context.SaveChanges();
            ReadParecerDto readDto = _mapper.Map<ReadParecerDto>(parecer);
            return readDto;
        }

        public List<ReadParecerDto> RecuperarPareceres()
        {
            List<ReadParecerDto> parecerDtos = _mapper.Map<List<ReadParecerDto>>(_context.Pareceres.ToList());
            return parecerDtos;
        }

        public ReadParecerDto RecuperarParecerPorId(int id)
        {
            Parecer parecer = _context.Pareceres.FirstOrDefault(parecer => parecer.Id == id);
            if (parecer == null)
            {
                return null;
            }
            ReadParecerDto readDto = _mapper.Map<ReadParecerDto>(parecer);
            return readDto;
        }

        public Result DeletarParecer(int id)
        {
            Parecer parecer = _context.Pareceres.FirstOrDefault(parecer => parecer.Id == id);
            if (parecer == null)
            {
                return Result.Fail("Parecer não encontrado");
            }
            _context.Remove(parecer);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
