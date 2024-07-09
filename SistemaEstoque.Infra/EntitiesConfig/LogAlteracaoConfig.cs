using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class LogAlteracaoConfig : IEntityTypeConfiguration<LogAlteracao>
    {
        public void Configure(EntityTypeBuilder<LogAlteracao> builder)
        {
            builder.ToTable("logs_alteracoes");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(l => l.Tabela)
                .HasColumnName("tabela")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(l => l.AlteradoEm)
                .HasColumnName("alterado_em")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(l => l.ItemId)
                .HasColumnName("item_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.DadosAntigos)
                .HasColumnName("dados_antigos")
                .HasColumnType("jsonb")
                .IsRequired();

            builder.Property(l => l.DadosNovos)
                .HasColumnName("dados_novos")
                .HasColumnType("jsonb")
                .IsRequired();

            builder.Property(l => l.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(l => l.UsuarioId)
                .HasColumnName("usuario_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(l => l.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(l => l.Usuario)
                .WithMany(u => u.LogsAlteracoes)
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.LogsAlteracoes)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
