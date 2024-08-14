﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VestibularAPI.Data;

#nullable disable

namespace VestibularAPI.Migrations
{
    [DbContext(typeof(VestibularContext))]
    [Migration("20240814214452_AtualizarRelacionamentos2")]
    partial class AtualizarRelacionamentos2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int?>("CandidatoId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumInscricao")
                        .HasColumnType("int");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessoSeletivoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("CandidatoId1");

                    b.HasIndex("OfertaId");

                    b.HasIndex("ProcessoSeletivoId");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("ProcessoSeletivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProcessosSeletivos");
                });

            modelBuilder.Entity("VestibularAPI.Models.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("VestibularAPI.Models.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VagasDisponiveis")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("Inscricao", b =>
                {
                    b.HasOne("VestibularAPI.Models.Candidato", null)
                        .WithMany()
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VestibularAPI.Models.Candidato", null)
                        .WithMany("Inscricoes")
                        .HasForeignKey("CandidatoId1");

                    b.HasOne("VestibularAPI.Models.Oferta", null)
                        .WithMany("Inscricoes")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcessoSeletivo", null)
                        .WithMany("Inscricoes")
                        .HasForeignKey("ProcessoSeletivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProcessoSeletivo", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("VestibularAPI.Models.Candidato", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("VestibularAPI.Models.Oferta", b =>
                {
                    b.Navigation("Inscricoes");
                });
#pragma warning restore 612, 618
        }
    }
}
