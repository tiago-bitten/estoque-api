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

            builder.Property(l => l.LoteId)
                .HasColumnName("lote_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.InsumoId)
                .HasColumnName("insumo_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Lote)
                .WithMany(l => l.LotesInsumos)
                .HasForeignKey(l => l.LoteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Insumo)
                .WithMany(i => i.LotesInsumos)
                .HasForeignKey(l => l.InsumoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(l => l.MovimentacoesInsumos)
                .WithOne(m => m.LoteInsumo)
                .HasForeignKey(m => m.LoteInsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.LotesInsumos)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
