using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

public class PermissaoBaseConfig : IdentificadorTenantConfig<PermissaoBase>
{
    public override void Configure(EntityTypeBuilder<PermissaoBase> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Criar)
            .HasColumnType("BOOLEAN")
            .HasColumnName("criar")
            .IsRequired();
        
        builder.Property(x => x.Editar)
            .HasColumnType("BOOLEAN")
            .HasColumnName("editar")
            .IsRequired();
        
        builder.Property(x => x.Excluir)
            .HasColumnType("BOOLEAN")
            .HasColumnName("excluir")
            .IsRequired();

        builder.Property(x => x.Visualizar)
            .HasColumnType("BOOLEAN")
            .HasColumnName("visualizar")
            .IsRequired();
        
        builder.Property(x => x.PerfilAcessoId)
            .HasColumnType("INT")
            .HasColumnName("perfil_acesso_id")
            .IsRequired();

        builder.HasOne(x => x.PerfilAcesso)
            .WithMany()
            .HasForeignKey(x => x.PerfilAcessoId);
    }
}