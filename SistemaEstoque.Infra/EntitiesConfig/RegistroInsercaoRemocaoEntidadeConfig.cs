using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig;

public class RegistroInsercaoRemocaoEntidadeConfig : RegistroEntidadeConfig<RegistroInsercaoRemocaoEntidade>
{
    public override void Configure(EntityTypeBuilder<RegistroInsercaoRemocaoEntidade> builder)
    {
        base.Configure(builder);

        builder.ToTable("registros_insercoes_remocoes");
        
        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.RegistroInsercaoRemocaoEntidades)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}