using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class MovimentacaoInsumoConfig : IEntityTypeConfiguration<MovimentacaoInsumo>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoInsumo> builder)
        {
            builder.ToTable("movimentacoes_insumos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(m => m.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("text")
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoMovimentacao)Enum.Parse(typeof(ETipoMovimentacao), v))
                .IsRequired();

            builder.Property(m => m.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.DataMovimentacao)
                .HasColumnName("data_movimentacao")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(m => m.PrecoUnitarioVenda)
                .HasColumnName("preco_unitario_venda")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(m => m.PrecoUnitarioCusto)
                .HasColumnName("preco_unitario_custo")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(m => m.Origem)
                .HasColumnName("origem")
                .HasColumnType("text")
                .HasConversion(
                    v => v.ToString(),
                    v => (EOrigemMovimentacao)Enum.Parse(typeof(EOrigemMovimentacao), v))
                .IsRequired();

            builder.Property(m => m.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(m => m.UsuarioId)
                .HasColumnName("usuario_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.InsumoId)
                .HasColumnName("insumo_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.LoteInsumoId)
                .HasColumnName("lote_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(m => m.Usuario)
                .WithMany(u => u.MovimentacoesInsumos)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Insumo)
                .WithMany(i => i.MovimentacoesInsumos)
                .HasForeignKey(m => m.InsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.LoteInsumo)
                .WithOne(l => l.MovimentacaoInsumo)
                .HasForeignKey<MovimentacaoInsumo>(m => m.LoteInsumoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Empresa)
                .WithMany(e => e.MovimentacoesInsumos)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
