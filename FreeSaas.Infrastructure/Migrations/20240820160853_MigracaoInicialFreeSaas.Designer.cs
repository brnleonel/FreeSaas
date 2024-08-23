﻿// <auto-generated />
using FreeSaas.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FreeSaas.Infrastructure.Migrations
{
    [DbContext(typeof(FreeSaasUOW))]
    [Migration("20240820160853_MigracaoInicialFreeSaas")]
    partial class MigracaoInicialFreeSaas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FreeSaas.Domain.Entities.Banco", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(3)
                        .HasColumnType("character varying");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.Property<string>("Site")
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Banco", null, t =>
                        {
                            t.HasComment("Febrabran");
                        });
                });

            modelBuilder.Entity("FreeSaas.Domain.Entities.Cbo", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(6)
                        .HasColumnType("character varying");

                    b.Property<string>("Aplicacao")
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Cbo", null, t =>
                        {
                            t.HasComment("Cadastro Brasileiro de Ocupação");
                        });
                });

            modelBuilder.Entity("FreeSaas.Domain.Entities.Cep", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(8)
                        .HasColumnType("character varying");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Cep", null, t =>
                        {
                            t.HasComment("Cep");
                        });
                });

            modelBuilder.Entity("FreeSaas.Domain.Entities.Cest", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(7)
                        .HasColumnType("character varying");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.Property<string>("Ncmsh")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Cest", null, t =>
                        {
                            t.HasComment("Cest");
                        });
                });

            modelBuilder.Entity("FreeSaas.Domain.Entities.Cfop", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Aplicacao")
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Cfop", null, t =>
                        {
                            t.HasComment("Cfop");
                        });
                });

            modelBuilder.Entity("FreeSaas.Domain.Entities.Cnae", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Cnae", null, t =>
                        {
                            t.HasComment("Cnae");
                        });
                });

            modelBuilder.Entity("FreeSaas.Domain.Entities.Ibge", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Ibge", null, t =>
                        {
                            t.HasComment("Ibge");
                        });
                });

            modelBuilder.Entity("FreeSaas.Domain.Entities.Ncm", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying");

                    b.HasKey("Codigo");

                    b.ToTable("Ncm", null, t =>
                        {
                            t.HasComment("NCM/SH");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
