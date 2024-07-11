using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class LoteInsumoConfig : IEntityTypeConfiguration<LoteInsumo>
    {
        public void Configure(EntityTypeBuilder<LoteInsumo> builder)
        {
            builder.ToTable("lotes_insumos");

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

            builder.Property(l => l.InsumoId)
                .HasColumnName("insumo_id")
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

            builder.HasOne(l => l.Insumo)
                .WithMany(i => i.LotesInsumos)
                .HasForeignKey(l => l.InsumoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Fornecedor)
                .WithMany(f => f.LotesInsumos)
                .HasForeignKey(l => l.FornecedorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.MovimentacaoInsumo)
                .WithOne(m => m.LoteInsumo)
                .HasForeignKey<MovimentoInsumo>(m => m.LoteInsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.LotesInsumos)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
