using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class FornecedorConfig : IdentificadorTenantConfig<Fornecedor>
    {
        public override void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");

            builder.Property(f => f.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(f => f.CpfCnpj)
                .HasColumnName("cpf_cnpj")
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(f => f.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(15)");

            builder.Property(f => f.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(150)");

            builder.Property(f => f.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(150)");

            builder.Property(f => f.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(150)");

            builder.Property(f => f.Estado)
                .HasColumnName("estado")
                .HasColumnType("varchar(2)");

            builder.Property(f => f.Cep)
                .HasColumnName("cep")
                .HasColumnType("varchar(8)");

            builder.HasMany(f => f.Lotes)
                .WithOne(l => l.Fornecedor)
                .HasForeignKey(l => l.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
