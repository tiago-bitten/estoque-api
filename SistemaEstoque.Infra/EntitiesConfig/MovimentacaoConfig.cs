using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class MovimentacaoConfig : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("movimentacoes");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(m => m.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("text")
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
                .IsRequired();

            builder.Property(m => m.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(m => m.UsuarioId)
                .HasColumnName("usuario_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.ProdutoId)
                .HasColumnName("produto_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.LoteId)
                .HasColumnName("lote_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(m => m.Usuario)
                .WithMany()
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        
            builder.HasOne(m => m.Produto)
                .WithMany()
                .HasForeignKey(m => m.ProdutoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Lote)
                .WithOne(l => l.Movimentacao)
                .HasForeignKey<Movimentacao>(m => m.LoteId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Empresa)
                .WithMany(e => e.Movimentacoes)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
