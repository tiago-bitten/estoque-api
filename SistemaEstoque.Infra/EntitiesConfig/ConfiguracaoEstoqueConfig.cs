using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class ConfiguracaoEstoqueConfig : IdentificadorTenantConfig<ConfiguracaoEstoque>
    {
        public override void Configure(EntityTypeBuilder<ConfiguracaoEstoque> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("configuracoes_estoques");

            builder.Property(c => c.PermitePassarEstoqueMinimo)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("permite_passar_estoque_minimo")
                .IsRequired();

            builder.Property(c => c.PermitePassarEstoqueMaximo)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("permite_passar_estoque_maximo")
                .IsRequired();

            builder.Property(c => c.PermiteEstoqueNegativo)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("permite_estoque_negativo")
                .IsRequired();

            builder.Property(c => c.NotificarEstoqueMaximo)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("notificar_estoque_maximo")
                .IsRequired();

            builder.Property(c => c.NotificarEstoqueMinimo)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("notificar_estoque_minimo")
                .IsRequired();

            builder.Property(c => c.PermiteSaidaSemLote)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("permite_saida_sem_lote")
                .IsRequired();

            builder.Property(c => c.PermiteEntradaSemLote)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("permite_entrada_sem_lote")
                .IsRequired();

            builder.HasOne(c => c.Empresa)
                .WithOne(e => e.ConfiguracaoEstoque)
                .HasForeignKey<ConfiguracaoEstoque>(c => c.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
