using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class CategoriaConfig : IdentificadorTenantConfig<Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("categorias");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(150)")
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(255)")
                .HasColumnName("descricao");

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
            
            builder.HasMany(x => x.Items)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.CategoriaId);

            builder.HasOne(c => c.Empresa)
                .WithMany(e => e.Categorias)
                .HasForeignKey(c => c.TenantId);
        }
    }
}
