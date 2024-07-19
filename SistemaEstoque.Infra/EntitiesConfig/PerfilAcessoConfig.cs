using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class PerfilAcessoConfig : IEntityTypeConfiguration<PerfilAcesso>
    {
        public void Configure(EntityTypeBuilder<PerfilAcesso> builder)
        {
            builder.ToTable("perfis_acessos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();
            
            builder.HasOne(p => p.PermissaoProduto)
                .WithOne(p => p.PerfilAcesso)
                .HasForeignKey<PerfilAcesso>(p => p.Id)
                .IsRequired();

            builder.HasMany(p => p.Usuarios)
                .WithOne(u => u.PerfilAcesso)
                .HasForeignKey(u => u.PerfilAcessoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.PerfisAcessos)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
