using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.CpfCnpj)
                .HasColumnName("cpf_cnpj")
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.TipoEmpresa)
                .HasColumnName("tipo_empresa")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(e => e.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(e => e.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("cep")
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property(e => e.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("BOOLEAN")
                .HasDefaultValue(true);

            builder.HasMany(e => e.Usuarios)
                .WithOne(u => u.Empresa)
                .HasForeignKey(u => u.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Categorias)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Produtos)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        
            builder.HasMany(e => e.Fornecedores)
                .WithOne(f => f.Empresa)
                .HasForeignKey(f => f.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
