using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Permissoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class PermissaoInsumoConfig : IEntityTypeConfiguration<PermissaoInsumo>
    {
        public void Configure(EntityTypeBuilder<PermissaoInsumo> builder)
        {
            builder.ToTable("permissoes_insumos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Visualizar)
                .HasColumnName("visualizar")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.Editar)
                .HasColumnName("editar")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.Criar)
                .HasColumnName("criar")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.Excluir)
                .HasColumnName("excluir")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.PerfilAcessoId)
                .HasColumnName("perfil_acesso_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(p => p.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();
        
            builder.HasOne(p => p.PerfilAcesso)
                .WithOne(pa => pa.PermissaoInsumo)
                .HasForeignKey<PermissaoInsumo>(p => p.PerfilAcessoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.PermissoesInsumos)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
