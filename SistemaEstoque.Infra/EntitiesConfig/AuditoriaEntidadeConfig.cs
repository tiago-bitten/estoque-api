using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class AuditoriaEntidadeConfig : IdentificadorTenantConfig<AuditoriaEntidade>
    {
        public override void Configure(EntityTypeBuilder<AuditoriaEntidade> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("auditorias_entidades");

            builder.Property(x => x.Tabela)
                .HasColumnType(TipoColunaConstants.Text)
                .HasColumnName("tabela")
                .IsRequired();

            builder.Property(x => x.EntidadeId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("entidade_id")
                .IsRequired();

            builder.Property(x => x.Data)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnType(TipoColunaConstants.Text)
                .HasConversion<ETipoAlteracao>()
                .IsRequired();

            builder.Property(x => x.UsuarioId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("usuario_id")
                .IsRequired();
            
            builder.Property(l => l.Quantidade)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(l => l.DadosAntigos)
                .HasColumnType(TipoColunaConstants.Jsonb)
                .HasColumnName("dados_antigos")
                .IsRequired();

            builder.Property(l => l.DadosNovos)
                .HasColumnType(TipoColunaConstants.Jsonb)
                .HasColumnName("dados_novos")
                .IsRequired();

            builder.HasOne(l => l.Usuario)
                .WithMany(u => u.AuditoriaEntidades)
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
