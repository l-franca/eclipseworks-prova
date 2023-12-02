using eclipseworks_teste.Entities;
using eclipseworks_teste.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Context
{
    public class EclipseContext : DbContext
    {
        public EclipseContext(DbContextOptions<EclipseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new HistoricoTarefaConfig());
            modelBuilder.ApplyConfiguration(new TarefaConfig());
            modelBuilder.ApplyConfiguration(new ProjetoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}

