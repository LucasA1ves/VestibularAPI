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
    [Migration("20240814194838_AddEmailAndTelefoneToCandidato")]
    partial class AddEmailAndTelefoneToCandidato
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VestibularAPI.Models.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

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

            modelBuilder.Entity("VestibularAPI.Models.Inscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("OfertaId");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("VestibularAPI.Models.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProcessoSeletivoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessoSeletivoId");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("VestibularAPI.Models.ProcessoSeletivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ProcessosSeletivos");
                });

            modelBuilder.Entity("VestibularAPI.Models.Inscricao", b =>
                {
                    b.HasOne("VestibularAPI.Models.Candidato", "Candidato")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VestibularAPI.Models.Oferta", "Oferta")
                        .WithMany("Inscricoes")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("VestibularAPI.Models.Oferta", b =>
                {
                    b.HasOne("VestibularAPI.Models.ProcessoSeletivo", null)
                        .WithMany("Ofertas")
                        .HasForeignKey("ProcessoSeletivoId");
                });

            modelBuilder.Entity("VestibularAPI.Models.Candidato", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("VestibularAPI.Models.Oferta", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("VestibularAPI.Models.ProcessoSeletivo", b =>
                {
                    b.Navigation("Ofertas");
                });
#pragma warning restore 612, 618
        }
    }
}
