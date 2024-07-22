using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities.Permissoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class PermissaoCategoriaConfig : IEntityTypeConfiguration<PermissaoCategoria>
    {
        public void Configure(EntityTypeBuilder<PermissaoCategoria> builder)
        {
            builder.ToTable("permissoes_categorias");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Visualizar)
                .HasColumnName("visualizar")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.Criar)
                .HasColumnName("criar")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.Editar)
                .HasColumnName("editar")
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
                .WithOne(p => p.PermissaoCategoria)
                .HasForeignKey<PermissaoCategoria>(p => p.PerfilAcessoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.PermissoesCategorias)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
