using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Repository.Configurations
{
    public class RegioesConfiguration : IEntityTypeConfiguration<Regioes>
    {
        public void Configure(EntityTypeBuilder<Regioes> builder)
        {
            builder.ToTable("Regioes");
            builder.HasKey(r => r.DDD);
            builder.Property(p => p.DDD).HasColumnType("INT").IsRequired().HasMaxLength(2);
            builder.Property(p => p.Regiao).HasColumnType("VARCHAR(20)").HasMaxLength(20);
            builder.Property(p => p.UF).HasColumnType("VARCHAR(20)").HasMaxLength(20);

            builder.HasData(FetchFromJson());
        }

        public static IEnumerable<Regioes> FetchFromJson()
        {
            var dir = Directory.GetParent(Directory.GetCurrentDirectory());

            var regioes = JsonConvert.DeserializeObject<IEnumerable<Regioes>>(File.ReadAllText(dir + "/Core/Data/BaseDDD.json")) 
                ?? throw new Exception("Não foi possível carregar os dados de BaseDDD.json");

            return regioes;
        }
    }
}
