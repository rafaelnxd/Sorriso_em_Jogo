using Microsoft.EntityFrameworkCore;
using Sorriso_em_Jogo.Domain.Entities.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Sorriso_em_Jogo.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Definição das tabelas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recompensa> Recompensas { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Habito> Habitos { get; set; }
        public DbSet<RegistroHabito> RegistrosHabito { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<UsuarioColetandoRecompensa> UsuariosColetandoRecompensa { get; set; }
        public DbSet<ProcedimentosDaUnidade> ProcedimentosDaUnidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração das chaves primárias compostas
            modelBuilder.Entity<UsuarioColetandoRecompensa>()
                .HasKey(uc => new { uc.UsuarioId, uc.RecompensaId });

            modelBuilder.Entity<ProcedimentosDaUnidade>()
                .HasKey(pu => new { pu.UnidadeId, pu.ProcedimentoId });
        }
    }
}
