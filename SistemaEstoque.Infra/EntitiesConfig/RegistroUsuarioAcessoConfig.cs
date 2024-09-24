using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class RegistroUsuarioAcessoConfig : IdentificadorTenantConfig<RegistroUsuarioAcesso>
    {
        public override void Configure(EntityTypeBuilder<RegistroUsuarioAcesso> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("registros_usuarios_acessos");

            builder.Property(h => h.UsuarioId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("usuario_id")
                .IsRequired();

            builder.Property(h => h.DataAcesso)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data_acesso")
                .IsRequired();

            builder.Property(h => h.IpAcesso)
                .HasColumnType($"{TipoColunaConstants.Varchar}(15)") // varchar(15)
                .HasColumnName("ip_acesso")
                .IsRequired();

            builder.Property(h => h.UserAgent)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("user_agent")
                .IsRequired();

            builder.Property(h => h.AcessoValido)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("acesso_valido")
                .IsRequired();

            builder.HasOne(h => h.Usuario)
                .WithMany(u => u.AuditoriaUsuarioAcessos)
                .HasForeignKey(h => h.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
