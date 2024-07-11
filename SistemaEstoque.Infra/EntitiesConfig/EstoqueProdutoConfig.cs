using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class EstoqueProdutoConfig : IEntityTypeConfiguration<EstoqueProduto>
    {
        public void Configure(EntityTypeBuilder<EstoqueProduto> builder)
        {
            builder.ToTable("estoques");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.QuantidadeMinima)
                .HasColumnName("quantidade_minima")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.QuantidadeMaxima)
                .HasColumnName("quantidade_maxima")
                .HasColumnType("int");

            builder.Property(e => e.Removido)
                .HasColumnName("removido")
                .HasColumnType("BOOLEAN")
                .HasDefaultValue(false);

            builder.Property(e => e.ProdutoId)
                .HasColumnName("produto_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(e => e.Produto)
                .WithOne(p => p.EstoqueProduto)
                .HasForeignKey<EstoqueProduto>(e => e.ProdutoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Empresa)
                .WithMany(em => em.EstoquesProdutos)
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
