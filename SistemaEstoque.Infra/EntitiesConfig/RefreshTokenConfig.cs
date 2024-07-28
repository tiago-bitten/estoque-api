using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig;

public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Token)
            .HasColumnName("token")
            .HasColumnName("varchar(50)")
            .IsRequired();

        builder.Property(x => x.ExpiraEm)
            .HasColumnName("expira_em")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.IsRevogado)
            .HasColumnName("is_revogado")
            .HasColumnType("boolean")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.UltimaGeracao)
            .HasColumnName("ultima_geracao")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .HasColumnName("usuario_id")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.EmpresaId)
            .HasColumnName("empresa_id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithOne(x => x.RefreshToken)
            .HasForeignKey<RefreshToken>(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Empresa)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.EmpresaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}