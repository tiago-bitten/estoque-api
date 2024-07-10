using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.TipoItem)
                .HasColumnName("tipo_item")
                .HasColumnType("text")
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoItem)System.Enum.Parse(typeof(ETipoItem), v))
                .IsRequired();

            builder.Property(c => c.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(c => c.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Insumos)
                .WithOne(i => i.Categoria)
                .HasForeignKey(i => i.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.Empresa)
                .WithMany(e => e.Categorias)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
