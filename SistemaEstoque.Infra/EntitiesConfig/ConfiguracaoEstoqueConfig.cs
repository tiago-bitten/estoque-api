using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class ConfiguracaoEstoqueConfig : IdentificadorTenantConfig<ConfiguracaoEstoque>
    {
        public override void Configure(EntityTypeBuilder<ConfiguracaoEstoque> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("configuracoes_estoques");

            builder.Property(c => c.PermitePassarEstoqueMinimo)
                .HasColumnName("permite_passar_estoque_minimo")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(c => c.PermitePassarEstoqueMaximo)
                .HasColumnName("permite_passar_estoque_maximo")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(c => c.PermiteEstoqueNegativo)
                .HasColumnName("permite_estoque_negativo")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(c => c.NotificarEstoqueMaximo)
                .HasColumnName("notificar_estoque_maximo")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(c => c.NotificarEstoqueMinimo)
                .HasColumnName("notificar_estoque_minimo")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(c => c.PermiteSaidaSemLote)
                .HasColumnName("permite_saida_sem_lote")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(c => c.PermiteEntradaSemLote)
                .HasColumnName("permite_entrada_sem_lote")
                .HasColumnType("boolean")
                .IsRequired();

            builder.HasOne(c => c.Empresa)
                .WithOne(e => e.ConfiguracaoEstoque)
                .HasForeignKey<ConfiguracaoEstoque>(c => c.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
