using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class MovimentacaoConfig : IdentificadorTenantConfig<Movimentacao>
    {
        public override void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("movimentacoes");

            builder.Property(m => m.Tipo)
                .HasColumnType(TipoColunaConstants.Text)
                .HasColumnName("tipo")
                .HasConversion<ETipoItem>()
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
                .HasConversion<EOrigemMovimentacao>()
                .IsRequired();

            builder.Property(m => m.UsuarioId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("usuario_id")
                .IsRequired();

            builder.Property(m => m.EstoqueId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("estoque_id")
                .IsRequired();

            builder.Property(m => m.ItemId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("item_id")
                .IsRequired();

            builder.Property(m => m.LoteItemId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("lote_id");

            builder.HasOne(m => m.Usuario)
                .WithMany(u => u.Movimentacoes)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Estoque)
                .WithMany(e => e.Movimentacoes)
                .HasForeignKey(m => m.EstoqueId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Movimentacoes)
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
