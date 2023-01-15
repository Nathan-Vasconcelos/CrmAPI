using CrmApi.Models;
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

            builder.Entity<Atendimento>()
                .HasOne(atendimento => atendimento.StatusAtendimento)
                .WithMany(statusAtendimento => statusAtendimento.Atendimentos)
                .HasForeignKey(atendimento => atendimento.StatusAtendimentoId);

            builder.Entity<Parecer>()
                .HasOne(parecer => parecer.ContatoAtendimento)
                .WithMany(contatoAtendimento => contatoAtendimento.Pareceres)
                .HasForeignKey(parecer => parecer.ContatoAtendimentoId);

            builder.Entity<Contrato>()
                .HasOne(contrato => contrato.Produto)
                .WithMany(produto => produto.Contratos)
                .HasForeignKey(contrato => contrato.ProdutoId);

            builder.Entity<Contrato>()
                .HasOne(contrato => contrato.Cliente)
                .WithMany(cliente => cliente.Contratos)
                .HasForeignKey(contrato => contrato.ClienteId);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimentos { get; set; }
        public DbSet<Parecer> Pareceres { get; set; }
        public DbSet<StatusAtendimento> StatusAtendimentos { get; set; }
        public DbSet<ContatoAtendimento> ContatoAtendimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
    }
}
