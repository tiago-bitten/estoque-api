using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig;

public class ItemConfig : IdentificadorTenantConfig<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);

        builder.ToTable("itens");

        builder.Property(x => x.Tipo)
            .HasColumnType(TipoColunaConstants.Text)
            .HasConversion<ETipoItem>()
            .IsRequired();
        
        builder.Property(x => x.Nome)
            .HasColumnType(TipoColunaConstants.VarcharDefault)
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType(TipoColunaConstants.VarcharDefault)
            .HasColumnName("descricao");
        
        builder.Property(x => x.PrecoCustoReferencia)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("preco_custo_referencia");
        
        builder.Property(x => x.PrecoVendaReferencia)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("preco_venda_referencia");
        
        builder.Property(x => x.CategoriaId)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("categoria_id")
            .IsRequired();
    }
}