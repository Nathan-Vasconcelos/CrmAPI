using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.ContratoDto;
using CrmApi.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrmApi.Services
{
    public class ContratoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ContratoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadContratoDto CriarContrato(CreateContratoDto contratoDto)
        {
            Contrato contrato = _mapper.Map<Contrato>(contratoDto);
            _context.Contratos.Add(contrato);
            _context.SaveChanges();
            ReadContratoDto readDto = _mapper.Map<ReadContratoDto>(contrato);
            return readDto;
        }

        public List<ReadContratoDto> RecuperarContratos()
        {
            List<ReadContratoDto> readDtos = _mapper.Map<List<ReadContratoDto>>(_context.Contratos.ToList());
            List<ReadContratoDto> listaContrato = new List<ReadContratoDto>();
            foreach (ReadContratoDto contrato in readDtos)
            {
                ReadContratoDto readContrato = CalcularDiferenca(contrato);
                listaContrato.Add(readContrato);
            }
            return listaContrato;
        }

        public ReadContratoDto RecuperarContratoPorId(int id)
        {
            Contrato contrato = _context.Contratos.FirstOrDefault(contrato => contrato.Id == id);
            if (contrato == null)
            {
                return null;
            }
            ReadContratoDto readDto = _mapper.Map<ReadContratoDto>(contrato);
            readDto = CalcularDiferenca(readDto);
            return readDto;
        }

        public Result EditarContrato(int id, UpdateContratoDto contratoDto)
        {
            Contrato contrato = _context.Contratos.FirstOrDefault(contrato => contrato.Id == id);
            if (contrato == null)
            {
                return Result.Fail("Contrato não encontrado");
            }
            _mapper.Map(contratoDto, contrato);
            _context.SaveChanges();
            return Result.Ok();
        }

        public ReadContratoDto CalcularDiferenca(ReadContratoDto contratoDto)
        {
            double diferenca = contratoDto.Valor - contratoDto.Produto.Valor;
            if (diferenca < 0)
            {
                contratoDto.Desconto = diferenca * -1;
            }
            if (diferenca > 0)
            {
                contratoDto.Acrescimo = diferenca;
            }
            return contratoDto;
        }
    }
}
