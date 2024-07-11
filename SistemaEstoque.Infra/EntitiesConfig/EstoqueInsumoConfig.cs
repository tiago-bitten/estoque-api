using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class EstoqueInsumoConfig : IEntityTypeConfiguration<EstoqueInsumo>
    {
        public void Configure(EntityTypeBuilder<EstoqueInsumo> builder)
        {
            builder.ToTable("estoques_insumos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
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

            builder.Property(e => e.InsumoId)
                .HasColumnName("insumo_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(e => e.Insumo)
                .WithOne(i => i.EstoqueInsumo)
                .HasForeignKey<EstoqueInsumo>(e => e.InsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Empresa)
                .WithMany(em => em.EstoquesInsumos)
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
