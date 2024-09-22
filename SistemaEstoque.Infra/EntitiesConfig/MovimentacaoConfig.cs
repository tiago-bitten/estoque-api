using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class MovimentacaoConfig : IdentificadorTenantConfig<Movimentacao>
    {
        public override void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("movimentacoes");

            builder.Property(x => x.Tipo)
                .HasColumnType(TipoColunaConstants.Text)
                .HasEnumConversion()
                .IsRequired();
            
            builder.Property(m => m.Quantidade)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(m => m.DataMovimentacao)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data_movimentacao")
                .IsRequired();

            builder.Property(m => m.PrecoUnitarioVenda)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("preco_unitario_venda")
                .IsRequired();

            builder.Property(m => m.PrecoUnitarioCusto)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("preco_unitario_custo")
                .IsRequired();

            builder.Property(m => m.Origem)
                .HasColumnType(TipoColunaConstants.Text)
                .HasColumnName("origem")
                .HasEnumConversion()
                .IsRequired();

            builder.Property(m => m.UsuarioId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("usuario_id")
                .IsRequired();

            builder.Property(m => m.ItemId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("item_id")
                .IsRequired();

            builder.Property(m => m.LoteId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("lote_id");

            builder.HasOne(x => x.Item)
                .WithMany(x => x.Movimentacoes)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Lote)
                .WithOne(x => x.Movimentacao)
                .HasForeignKey<Lote>(x => x.ItemId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Usuario)
                .WithMany(u => u.Movimentacoes)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Movimentacoes)
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
