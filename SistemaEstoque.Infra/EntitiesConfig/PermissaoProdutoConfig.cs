using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class PermissaoProdutoConfig : PermissaoBaseConfig<PermissaoProduto>
    {
        public override void Configure(EntityTypeBuilder<PermissaoProduto> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("permissoes_produtos");

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.PermissoesProdutos)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
