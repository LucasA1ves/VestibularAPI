using Microsoft.EntityFrameworkCore;
using VestibularAPI.Models;

namespace VestibularAPI.Data
{
    public class VestibularContext : DbContext
    {
        public VestibularContext(DbContextOptions<VestibularContext> options) : base(options)
        {
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CPF).IsRequired().HasMaxLength(15);
                entity.Property(e => e.DataNascimento).IsRequired();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Telefone).IsRequired().HasMaxLength(20);

                // Definir relacionamento com Inscricao
                entity.HasMany<Inscricao>()
                      .WithOne()
                      .HasForeignKey(i => i.CandidatoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Relacionamento com Candidato
                entity.HasOne<Candidato>()
                      .WithMany()
                      .HasForeignKey(i => i.CandidatoId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relacionamento com Oferta
                entity.HasOne<Oferta>()
                      .WithMany()
                      .HasForeignKey(i => i.OfertaId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relacionamento com Processo Seletivo
                entity.HasOne<ProcessoSeletivo>()
                      .WithMany()
                      .HasForeignKey(i => i.ProcessoSeletivoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descricao).HasMaxLength(500);

                // Relacionamento com Inscricao
                entity.HasMany<Inscricao>()
                      .WithOne()
                      .HasForeignKey(i => i.OfertaId);
            });

            modelBuilder.Entity<ProcessoSeletivo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descricao).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DataInicio).IsRequired();
                entity.Property(e => e.DataTermino).IsRequired();

                // Relacionamento com Inscricao
                entity.HasMany<Inscricao>()
                      .WithOne()
                      .HasForeignKey(i => i.ProcessoSeletivoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
