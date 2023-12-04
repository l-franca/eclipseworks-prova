using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eclipseworks_teste.EntityConfigs
{
    public class TarefaConfig : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.CodTarefa);
            builder.HasOne(x => x.Projeto)
                .WithMany(x => x.Tarefas)
                .HasForeignKey(x => x.CodProjeto)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.HistoricoTarefa)
                .WithOne(x=>x.Tarefa)
                .HasForeignKey(x=>x.CodTarefa)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Tarefas)
                .HasForeignKey(x => x.CodUsuario);
            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.Descricao)
                .IsRequired();
            builder.Property(x => x.Status)
                .IsRequired();
            builder.Property(x => x.CodUsuario)
                .IsRequired();
            builder.Property(x => x.DataVencimento)
                .IsRequired();
            builder.Property(x => x.Prioridade)
               .IsRequired();

        }
    }
}