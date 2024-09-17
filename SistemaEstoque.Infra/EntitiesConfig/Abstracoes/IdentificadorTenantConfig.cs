using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

public class IdentificadorTenantConfig<T> : IdentificadorBaseConfig<T> where T : IdentificadorTenant
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.TenantId)
            .HasColumnType("int")
            .HasColumnName("tenant_id")
            .IsRequired();

        builder.HasOne(x => x.Empresa)
            .WithMany()
            .HasForeignKey(x => x.TenantId);

        builder.HasIndex(x => x.TenantId);
    }
}