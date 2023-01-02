﻿using CrmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Atendimento>()
                .HasOne(atendimento => atendimento.Usuario)
                .WithMany(usuario => usuario.Atendimentos)
                .HasForeignKey(atendimento => atendimento.UsuarioId);

            builder.Entity<Atendimento>()
                .HasOne(atendimento => atendimento.Cliente)
                .WithMany(cliente => cliente.Atendimentos)
                .HasForeignKey(atendimento => atendimento.ClienteId);

            builder.Entity<Atendimento>()
                .HasOne(atendimento => atendimento.TipoAtendimento)
                .WithMany(tipoAtendimento => tipoAtendimento.Atendimentos)
                .HasForeignKey(atendimento => atendimento.TipoAtendimentoId);

            builder.Entity<Parecer>()
                .HasOne(parecer => parecer.Atendimento)
                .WithMany(atendimento => atendimento.Pareceres)
                .HasForeignKey(parecer => parecer.AtendimentoId);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimentos { get; set; }
        public DbSet<Parecer> Pareceres { get; set; }
    }
}