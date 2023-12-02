using eclipseworks_teste.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eclipseworks_teste.EntityConfigs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.CodUsuario);
            builder.HasMany(x => x.Projeto)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.CodProjeto);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.Cargo)
                .IsRequired();
        }
    }
}