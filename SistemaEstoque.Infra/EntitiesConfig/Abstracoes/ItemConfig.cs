using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

public class ItemConfig : IdentificadorTenantConfig<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("nome")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("VARCHAR(500)")
            .HasColumnName("descricao");
        
        builder.Property(x => x.PrecoCustoReferencia)
            .HasColumnType("DECIMAL(10,2)")
            .HasColumnName("preco_custo_referencia");
        
        builder.Property(x => x.PrecoVendaReferencia)
            .HasColumnType("DECIMAL(10,2)")
            .HasColumnName("preco_venda_referencia");
        
        builder.Property(x => x.CategoriaId)
            .HasColumnType("INT")
            .HasColumnName("categoria_id")
            .IsRequired();

        builder.HasOne(x => x.Categoria)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.CategoriaId);
    }
}