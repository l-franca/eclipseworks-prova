using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eclipseworks_teste.EntityConfigs
{
    public class HistoricoTarefaConfig : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> builder)
        {
            builder.HasKey(x => x.CodHistorico);
            builder.HasOne(x => x.Tarefa)
                .WithMany(x => x.HistoricoTarefa)
                .HasForeignKey(x => x.CodHistorico);
            builder.Property(x => x.Titulo)
                .HasMaxLength(255);
            builder.Property(x => x.DataModificacao)
                .IsRequired();
            builder.Property(x => x.StatusHistorico)
                .IsRequired();
            builder.Property(x => x.CodTarefa)
                .IsRequired();
        }
    }
}