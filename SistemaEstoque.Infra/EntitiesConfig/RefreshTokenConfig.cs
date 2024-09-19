using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig;

public class RefreshTokenConfig : IdentificadorTenantConfig<RefreshToken>
{
    public override void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("refresh_tokens");

        builder.Property(x => x.Token)
            .HasColumnName(TipoColunaConstants.VarcharDefault)
            .HasColumnName("token")
            .IsRequired();

        builder.Property(x => x.ExpiraEm)
            .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
            .HasColumnName("expira_em")
            .IsRequired();

        builder.Property(x => x.IsRevogado)
            .HasColumnType(TipoColunaConstants.Boolean)
            .HasColumnName("is_revogado")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.UltimaGeracao)
            .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .HasColumnType(TipoColunaConstants.Int)
            .HasColumnName("usuario_id")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithOne(x => x.RefreshToken)
            .HasForeignKey<RefreshToken>(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Empresa)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.TenantId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}