using AutoMapper;
using CrmApi.Data;
using CrmApi.Data.UsuarioDto;
using CrmApi.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrmApi.Services
{
    public class UsuarioService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadUsuarioDto CriarUsuario(CreateUsuarioDto usuarioDto)
        {
            bool resultado = ValidarCpf(usuarioDto.Cpf);
            if (!resultado)
            {
                return null;
            }

            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            ReadUsuarioDto readDto = _mapper.Map<ReadUsuarioDto>(usuario);
            return readDto;
        }

        public List<ReadUsuarioDto> RecuperarUsuarios()
        {
            List<ReadUsuarioDto> usuariosDto = _mapper.Map<List<ReadUsuarioDto>>(_context.Usuarios.ToList());
            return usuariosDto;
        }

        public ReadUsuarioDto RecuperarUsuarioPorId(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
            if (usuario == null)
            {
                return null;
            }

            ReadUsuarioDto usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
            return usuarioDto;
        }

        public Result EditarUsuario(int id, UpdateUsuarioDto usuarioDto)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
            if (usuario == null)
            {
                return Result.Fail("Usuário não encontrado");
            }

            bool resultado = ValidarCpf(usuarioDto.Cpf, id);
            if (!resultado)
            {
                return null;
            }

            _mapper.Map(usuarioDto, usuario);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarUsuario(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
            if (usuario == null)
            {
                return Result.Fail("Usuário não encontrado");
            }

            _context.Remove(usuario);
            _context.SaveChanges();
            return Result.Ok();
        }

        public bool ValidarCpf(string cpf, int? id = null)
        {
            bool resultado = Regex.IsMatch(cpf, "^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}");
            if (!resultado)
            {
                return resultado;
            }

            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Cpf == cpf);
            if (usuario == null)
            {
                return true;
            }
            if (id != null)
            {
                if (usuario.Id == id)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
