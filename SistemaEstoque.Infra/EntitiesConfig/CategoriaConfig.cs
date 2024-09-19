using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class CategoriaConfig : IdentificadorTenantConfig<Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("categorias");

            builder.Property(c => c.Nome)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("descricao");

            builder.Property(c => c.TipoItem)
                .HasColumnType(TipoColunaConstants.Text)
                .HasColumnName("tipo_item")
                .HasConversion<ETipoItem>()
                .IsRequired();

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Categoria)
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.Empresa)
                .WithMany(e => e.Categorias)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
