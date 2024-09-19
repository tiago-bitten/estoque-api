using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class UsuarioConfig : IdentificadorTenantConfig<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("usuarios");

            builder.Property(u => u.Nome)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("senha")
                .IsRequired();

            builder.Property(u => u.PerfilAcessoId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("perfil_acesso_id");

            builder.Property(u => u.AcessoBloqueado)
                .HasColumnType(TipoColunaConstants.Boolean)
                .HasColumnName("acesso_bloqueado")
                .HasDefaultValue(false);

            builder.HasOne(u => u.PerfilAcesso)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.PerfilAcessoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.Empresa)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(u => u.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.RegistroAlteracaoEntidades)
                .WithOne(l => l.Usuario)
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.RegistroInsercaoRemocaoEntidades)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Movimentacoes)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.HistoricosUsuariosAcessos)
                .WithOne(h => h.Usuario)
                .HasForeignKey(h => h.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.Lotes)
                .WithOne(l => l.UsuarioRecebimento)
                .HasForeignKey(l => l.UsuarioRecebimentoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.RefreshToken)
                .WithOne(x => x.Usuario)
                .HasForeignKey<RefreshToken>(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
