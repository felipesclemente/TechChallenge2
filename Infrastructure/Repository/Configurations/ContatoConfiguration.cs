using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired().HasMaxLength(100);
            builder.Property(p => p.DDD).HasColumnType("INT").IsRequired().HasMaxLength(2);
            builder.Property(p => p.Telefone).HasColumnType("INT").IsRequired().HasMaxLength(9);
            builder.Property(p => p.Email).HasColumnType("VARCHAR(100)").HasMaxLength(100);

            builder.HasOne(c => c.Regiao).WithMany().HasForeignKey(c => c.DDD).HasPrincipalKey(r => r.DDD);
        }
    }
}
