using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

public class RegistroEntidadeConfig<T> : IdentificadorTenantConfig<T> where T : RegistroEntidade
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Tabela)
            .HasColumnType(TipoColunaConstants.Text)
            .HasColumnName("tabela")
            .IsRequired();

        builder.Property(x => x.ItemId)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("item_id")
            .IsRequired();

        builder.Property(x => x.Data)
            .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
            .HasColumnName("data")
            .IsRequired();

        builder.Property(x => x.Tipo)
            .HasColumnType(TipoColunaConstants.Text)
            .HasConversion<ETipoAlteracao>()
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("usuario_id")
            .IsRequired();
    }
}