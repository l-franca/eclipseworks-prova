using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eclipseworks_teste.EntityConfigs
{
    public class ProjetoConfig : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(x => x.CodProjeto);
            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Projeto)
                .HasForeignKey(x => x.CodUsuario);
            builder.Property(x => x.Titulo)
               .IsRequired()
               .HasMaxLength(256);
            builder.Property(x => x.Descricao)
               .IsRequired();
            builder.Property(x => x.Data)
                .IsRequired();
        }
    }
}