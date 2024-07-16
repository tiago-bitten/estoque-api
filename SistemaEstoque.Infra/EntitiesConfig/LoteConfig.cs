using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class LoteConfig : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.ToTable("lotes");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(l => l.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(l => l.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(l => l.CodigoBarras)
                .HasColumnName("codigo_barras")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(l => l.FornecedorId)
                .HasColumnName("fornecedor_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.DataRecebimento)
                .HasColumnName("data_recebimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(l => l.UsuarioRecebimentoId)
                .HasColumnName("usuario_recebimento_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(l => l.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Fornecedor)
                .WithMany(f => f.Lotes)
                .HasForeignKey(l => l.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.UsuarioRecebimento)
                .WithMany(u => u.Lotes)
                .HasForeignKey(l => l.UsuarioRecebimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.Lotes)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
