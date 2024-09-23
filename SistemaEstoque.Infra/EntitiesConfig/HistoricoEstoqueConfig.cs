using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class HistoricoEstoqueConfig : IdentificadorTenantConfig<HistoricoEstoque>
    {
        public override void Configure(EntityTypeBuilder<HistoricoEstoque> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("historicos_estoques");

            builder.Property(h => h.EstoqueId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("estoque_id")
                .IsRequired();

            builder.Property(h => h.Data)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data")
                .IsRequired();
            
            builder.Property(x => x.Quantidade)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(h => h.DataRegistro)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data_registro")
                .IsRequired();
        
            builder.HasOne(h => h.Estoque)
                .WithMany(e => e.HistoricoEstoques)
                .HasForeignKey(h => h.EstoqueId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.HistoricoEstoques)
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
