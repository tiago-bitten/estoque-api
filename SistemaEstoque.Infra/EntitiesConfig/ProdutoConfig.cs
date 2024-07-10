using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(150)");

            builder.Property(p => p.PrecoVendaReferencia)
                .HasColumnName("preco_venda_referencia")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PrecoCustoReferencia)
                .HasColumnName("preco_custo_referencia")
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(p => p.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.Produtos)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.LotesProdutos)
                .WithOne(l => l.Produto)
                .HasForeignKey(l => l.ProdutoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
