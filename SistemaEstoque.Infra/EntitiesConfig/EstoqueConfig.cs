using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class EstoqueConfig : IdentificadorTenantConfig<Estoque>
    {
        public override void Configure(EntityTypeBuilder<Estoque> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("estoques");

            builder.Property(e => e.Quantidade)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(e => e.QuantidadeMinima)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("quantidade_minima")
                .IsRequired();

            builder.Property(e => e.QuantidadeMaxima)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("quantidade_maxima");

            builder.Property(e => e.ItemId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("item_id")
                .IsRequired();

            builder.HasOne(x => x.Item)
                .WithMany(x => x.Estoques)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Estoques)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
