using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class LoteConfig : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.ToTable("lotes");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(l => l.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(l => l.CodigoBarras)
                .HasColumnName("codigo_barras")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(l => l.DataFabricacao)
                .HasColumnName("data_fabricacao")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(l => l.DataValidade)
                .HasColumnName("data_validade")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(l => l.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(l => l.ProdutoId)
                .HasColumnName("produto_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.FornecedorId)
                .HasColumnName("fornecedor_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Produto)
                .WithMany(p => p.Lotes)
                .HasForeignKey(l => l.ProdutoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Fornecedor)
                .WithMany(f => f.Lotes)
                .HasForeignKey(l => l.FornecedorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Movimentacao)
                .WithOne(m => m.Lote)
                .HasForeignKey<Movimentacao>(m => m.LoteId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.Lotes)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
