using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class PermissaoInsumoConfig : PermissaoBaseConfig<PermissaoInsumo>
    {
        public override void Configure(EntityTypeBuilder<PermissaoInsumo> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("permissoes_insumos");

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.PermissoesInsumos)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
