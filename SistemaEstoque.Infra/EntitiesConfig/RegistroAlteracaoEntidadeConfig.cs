using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class RegistroAlteracaoEntidadeConfig : RegistroEntidadeConfig<RegistroAlteracaoEntidade>
    {
        public override void Configure(EntityTypeBuilder<RegistroAlteracaoEntidade> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("registros_alteracooes_entidades");

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

            builder.HasOne(l => l.Usuario)
                .WithMany(u => u.RegistroAlteracaoEntidades)
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
