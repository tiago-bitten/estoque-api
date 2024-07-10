using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class FornecedorConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

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

            builder.Property(f => f.Removido)
                .HasColumnName("removido")
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.Property(f => f.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Fornecedores)
                .HasForeignKey(f => f.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(f => f.LotesProdutos)
                .WithOne(l => l.Fornecedor)
                .HasForeignKey(l => l.FornecedorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
