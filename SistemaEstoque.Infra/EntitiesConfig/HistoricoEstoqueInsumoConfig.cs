using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class HistoricoEstoqueInsumoConfig : IEntityTypeConfiguration<HistoricoEstoqueInsumo>
    {
        public void Configure(EntityTypeBuilder<HistoricoEstoqueInsumo> builder)
        {
            builder.ToTable("historicos_estoques_insumos");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(h => h.EstoqueInsumoId)
                .HasColumnName("estoque_insumo_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(h => h.Data)
                .HasColumnName("data")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(h => h.DataRegistro)
                .HasColumnName("data_registro")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(h => h.EstoqueInsumo)
                .WithMany(e => e.HistoricosEstoquesInsumos)
                .HasForeignKey(h => h.EstoqueInsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(h => h.Empresa)
                .WithMany(e => e.HistoricosEstoquesInsumos)
                .HasForeignKey(h => h.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
