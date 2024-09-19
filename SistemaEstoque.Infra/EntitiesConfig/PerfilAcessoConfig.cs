using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class PerfilAcessoConfig : IdentificadorTenantConfig<PerfilAcesso>
    {
        public override void Configure(EntityTypeBuilder<PerfilAcesso> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("perfis_acessos");

            builder.Property(p => p.Nome)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("nome")
                .IsRequired();

            builder.HasOne(p => p.PermissaoProduto)
                .WithOne(p => p.PerfilAcesso)
                .HasForeignKey<PerfilAcesso>(p => p.Id)
                .IsRequired();

            builder.HasOne(p => p.PermissaoCategoria)
                .WithOne(p => p.PerfilAcesso)
                .HasForeignKey<PerfilAcesso>(p => p.Id)
                .IsRequired();

            builder.HasMany(p => p.Usuarios)
                .WithOne(u => u.PerfilAcesso)
                .HasForeignKey(u => u.PerfilAcessoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.PerfisAcessos)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
