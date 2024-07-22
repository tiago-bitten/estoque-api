using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class ConfiguracaoEstoqueConfig : IEntityTypeConfiguration<ConfiguracaoEstoque>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoEstoque> builder)
        {
            builder.ToTable("configuracoes_estoques");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

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

            builder.Property(c => c.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(c => c.Empresa)
                .WithOne(e => e.ConfiguracaoEstoque)
                .HasForeignKey<ConfiguracaoEstoque>(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
