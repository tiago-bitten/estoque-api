using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

public class IdentificadorBaseConfig<T> : IEntityTypeConfiguration<T> where T : IdentificadorBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(typeof(T).Name);
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("INT")
            .HasColumnType("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Removido)
            .HasColumnType("BOOLEAN")
            .HasColumnName("removido")
            .HasDefaultValue(false)
            .IsRequired();
    }
}