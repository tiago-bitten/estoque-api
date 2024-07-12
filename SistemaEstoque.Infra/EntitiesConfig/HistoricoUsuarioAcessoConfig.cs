using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class HistoricoUsuarioAcessoConfig : IEntityTypeConfiguration<HistoricoUsuarioAcesso>
    {
        public void Configure(EntityTypeBuilder<HistoricoUsuarioAcesso> builder)
        {
            builder.ToTable("historicos_usuarios_acessos");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(h => h.UsuarioId)
                .HasColumnName("usuario_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(h => h.DataAcesso)
                .HasColumnName("data_acesso")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(h => h.IpAcesso)
                .HasColumnName("ip_acesso")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(h => h.UserAgent)
                .HasColumnName("user_agent")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(h => h.AcessoValido)
                .HasColumnName("acesso_valido")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(h => h.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(h => h.Usuario)
                .WithMany(u => u.HistoricosUsuariosAcessos)
                .HasForeignKey(h => h.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(h => h.Empresa)
                .WithMany(e => e.HistoricosUsuariosAcessos)
                .HasForeignKey(h => h.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
