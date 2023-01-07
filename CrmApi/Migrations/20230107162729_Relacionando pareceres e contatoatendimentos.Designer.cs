﻿// <auto-generated />
using System;
using CrmApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrmApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230107162729_Relacionando pareceres e contatoatendimentos")]
    partial class Relacionandopareceresecontatoatendimentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CrmApi.Models.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("StatusAtendimentoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoAtendimentoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("StatusAtendimentoId");

                    b.HasIndex("TipoAtendimentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("CrmApi.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CrmApi.Models.ContatoAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ContatoAtendimentos");
                });

            modelBuilder.Entity("CrmApi.Models.Parecer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AtendimentoId")
                        .HasColumnType("int");

                    b.Property<int>("ContatoAtendimentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AtendimentoId");

                    b.HasIndex("ContatoAtendimentoId");

                    b.ToTable("Pareceres");
                });

            modelBuilder.Entity("CrmApi.Models.StatusAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("StatusAtendimentos");
                });

            modelBuilder.Entity("CrmApi.Models.TipoAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoAtendimentos");
                });

            modelBuilder.Entity("CrmApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CrmApi.Models.Atendimento", b =>
                {
                    b.HasOne("CrmApi.Models.Cliente", "Cliente")
                        .WithMany("Atendimentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrmApi.Models.StatusAtendimento", "StatusAtendimento")
                        .WithMany("Atendimentos")
                        .HasForeignKey("StatusAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrmApi.Models.TipoAtendimento", "TipoAtendimento")
                        .WithMany("Atendimentos")
                        .HasForeignKey("TipoAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrmApi.Models.Usuario", "Usuario")
                        .WithMany("Atendimentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("StatusAtendimento");

                    b.Navigation("TipoAtendimento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CrmApi.Models.Parecer", b =>
                {
                    b.HasOne("CrmApi.Models.Atendimento", "Atendimento")
                        .WithMany("Pareceres")
                        .HasForeignKey("AtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrmApi.Models.ContatoAtendimento", "ContatoAtendimento")
                        .WithMany("Pareceres")
                        .HasForeignKey("ContatoAtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendimento");

                    b.Navigation("ContatoAtendimento");
                });

            modelBuilder.Entity("CrmApi.Models.Atendimento", b =>
                {
                    b.Navigation("Pareceres");
                });

            modelBuilder.Entity("CrmApi.Models.Cliente", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("CrmApi.Models.ContatoAtendimento", b =>
                {
                    b.Navigation("Pareceres");
                });

            modelBuilder.Entity("CrmApi.Models.StatusAtendimento", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("CrmApi.Models.TipoAtendimento", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("CrmApi.Models.Usuario", b =>
                {
                    b.Navigation("Atendimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
