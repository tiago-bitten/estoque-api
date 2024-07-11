using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class InsumoConfig : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("insumos");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(i => i.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(i => i.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(i => i.PrecoCustoReferencia)
                .HasColumnName("preco_custo_referencia")
                .HasColumnType("decimal(10,2)");

            builder.Property(i => i.PrecoVendaReferencia)
                .HasColumnName("preco_venda_referencia")
                .HasColumnType("decimal(10,2)");

            builder.Property(i => i.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(i => i.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(i => i.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(i => i.Categoria)
                .WithMany(c => c.Insumos)
                .HasForeignKey(i => i.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.EstoqueInsumo)
                .WithOne(e => e.Insumo)
                .HasForeignKey<EstoqueInsumo>(e => e.InsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(i => i.LotesInsumos)
                .WithOne(l => l.Insumo)
                .HasForeignKey(l => l.InsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(i => i.MovimentacoesInsumos)
                .WithOne(m => m.Insumo)
                .HasForeignKey(m => m.InsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.Empresa)
                .WithMany(e => e.Insumos)
                .HasForeignKey(i => i.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);        
        }
    }
}
