using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

public class PermissaoBaseConfig<T> : IdentificadorTenantConfig<T> where T : PermissaoBase
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Criar)
            .HasColumnType(TipoColunaConstants.Boolean)
            .HasColumnName("criar")
            .IsRequired();
        
        builder.Property(x => x.Editar)
            .HasColumnType(TipoColunaConstants.Boolean)
            .HasColumnName("editar")
            .IsRequired();
        
        builder.Property(x => x.Excluir)
            .HasColumnType(TipoColunaConstants.Boolean)
            .HasColumnName("excluir")
            .IsRequired();

        builder.Property(x => x.Visualizar)
            .HasColumnType(TipoColunaConstants.Boolean)
            .HasColumnName("visualizar")
            .IsRequired();
        
        builder.Property(x => x.PerfilAcessoId)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("perfil_acesso_id")
            .IsRequired();

        builder.HasOne(x => x.PerfilAcesso)
            .WithMany()
            .HasForeignKey(x => x.PerfilAcessoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}