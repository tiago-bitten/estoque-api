using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class HistoricoEstoqueProdutoConfig : IEntityTypeConfiguration<HistoricoEstoqueProduto>
    {
        public void Configure(EntityTypeBuilder<HistoricoEstoqueProduto> builder)
        {
            builder.ToTable("historicos_estoques_produtos");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(h => h.EstoqueProdutoId)
                .HasColumnName("estoque_produto_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(h => h.Data)
                .HasColumnName("data")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(h => h.DataRegistro)
                .HasColumnName("data_registro")
                .HasColumnType("date")
                .IsRequired();
        
            builder.HasOne(h => h.EstoqueProduto)
                .WithMany(e => e.HistoricosEstoquesProdutos)
                .HasForeignKey(h => h.EstoqueProdutoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(h => h.Empresa)
                .WithMany(e => e.HistoricosEstoquesProdutos)
                .HasForeignKey(h => h.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
