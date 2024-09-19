using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class ProprietarioConfig : IdentificadorTenantConfig<Proprietario>
    {
        public override void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("proprietarios");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("data_nascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.HasMany(p => p.Empresas)
                .WithOne(e => e.Proprietario)
                .HasForeignKey(e => e.ProprietarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
