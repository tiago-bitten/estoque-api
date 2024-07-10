using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class MovimentacaoProdutoConfig : IEntityTypeConfiguration<MovimentacaoProduto>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoProduto> builder)
        {
            builder.ToTable("movimentacoes_produtos");

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

            builder.Property(m => m.LoteProdutoId)
                .HasColumnName("lote_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(m => m.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(m => m.Usuario)
                .WithMany(u => u.MovimentacoesProdutos)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        
            builder.HasOne(m => m.Produto)
                .WithMany(p => p.MovimentacoesProdutos)
                .HasForeignKey(m => m.ProdutoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.LoteProduto)
                .WithOne(l => l.MovimentacaoProduto)
                .HasForeignKey<MovimentacaoProduto>(m => m.LoteProdutoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Empresa)
                .WithMany(e => e.MovimentacoesProdutos)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
