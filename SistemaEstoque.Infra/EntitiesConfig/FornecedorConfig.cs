using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class FornecedorConfig : IdentificadorTenantConfig<Fornecedor>
    {
        public override void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");

            builder.Property(f => f.Nome)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(f => f.CpfCnpj)
                .HasColumnType(TipoColunaConstants.VarcharCpfCnpj)
                .HasColumnName("cpf_cnpj")
                .IsRequired();

            builder.Property(f => f.Telefone)
                .HasColumnType(TipoColunaConstants.VarcharCelular)
                .HasColumnName("telefone");

            builder.Property(f => f.Email)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("email");

            builder.Property(f => f.Endereco)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("endereco");

            builder.Property(f => f.Cidade)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("cidade");

            builder.Property(f => f.Estado)
                .HasColumnType($"{TipoColunaConstants.Varchar}(2)")
                .HasColumnName("estado");

            builder.Property(f => f.Cep)
                .HasColumnType(TipoColunaConstants.VarcharCep)
                .HasColumnName("cep");

            builder.HasMany(f => f.Lotes)
                .WithOne(l => l.Fornecedor)
                .HasForeignKey(l => l.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Fornecedores)
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
