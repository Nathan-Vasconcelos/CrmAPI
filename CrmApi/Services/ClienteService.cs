using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.ClienteDto;
using CrmApi.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrmApi.Services
{
    public class ClienteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadClienteDto CriarCLiente(CreateClienteDto clienteDto)
        {
            bool resultado = ValidarCnpj(clienteDto.Cnpj);
            if (!resultado)
            {
                return null;
            }

            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            ReadClienteDto readDto = _mapper.Map<ReadClienteDto>(cliente);
            return readDto;
        }

        public List<ReadClienteDto> RecuperarClientes()
        {
            List<ReadClienteDto> clientesDto = _mapper.Map<List<ReadClienteDto>>(_context.Clientes.ToList());
            return clientesDto;
        }

        public ReadClienteDto RecuperarClientePorId(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return null;
            }
            ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);
            return clienteDto;
        }

        public Result EditarCLiente(int id, UpdateClienteDto clienteDto)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return Result.Fail("Cliente não encontrado");
            }

            bool resultado = ValidarCnpj(clienteDto.Cnpj, id);
            if (!resultado)
            {
                return null;
            }

            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarCliente(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if ( cliente == null)
            {
                return Result.Fail("Cliente não encontrado");
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public bool ValidarCnpj(string cnpj, int? id = null)
        {
            bool resultado = Regex.IsMatch(cnpj, "^[0-9]{2}.[0-9]{3}.[0-9]{3}/[0-9]{4}-[0-9]{2}");
            if (!resultado)
            {
                return resultado;
            }

            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Cnpj == cnpj);
            if (cliente == null)
            {
                return true;
            }
            if (id != null)
            {
                if (cliente.Id == id)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
