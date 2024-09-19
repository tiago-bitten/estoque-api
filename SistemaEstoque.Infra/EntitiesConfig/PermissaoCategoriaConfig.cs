using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class PermissaoCategoriaConfig : PermissaoBaseConfig<PermissaoCategoria>
    {
        public override void Configure(EntityTypeBuilder<PermissaoCategoria> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("permissoes_categorias");

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.PermissoesCategorias)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
