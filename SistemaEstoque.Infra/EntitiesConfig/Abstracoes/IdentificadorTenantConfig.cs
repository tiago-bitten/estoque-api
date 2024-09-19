using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

public class IdentificadorTenantConfig<T> : IdentificadorBaseConfig<T> where T : IdentificadorTenant
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.TenantId)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("tenant_id")
            .IsRequired();

        builder.HasIndex(x => x.TenantId);
    }
}