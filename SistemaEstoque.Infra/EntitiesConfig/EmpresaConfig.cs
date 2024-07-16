using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;

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
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoEmpresa)System.Enum.Parse(typeof(ETipoEmpresa), v))
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

            builder.HasMany(e => e.LotesProdutos)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.LotesInsumos)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.MovimentacoesProdutos)
                .WithOne(m => m.Empresa)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        
            builder.HasMany(e => e.MovimentacoesInsumos)
                .WithOne(m => m.Empresa)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.EstoquesProdutos)
                .WithOne(es => es.Empresa)
                .HasForeignKey(es => es.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.EstoquesInsumos)
                .WithOne(es => es.Empresa)
                .HasForeignKey(es => es.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Insumos)
                .WithOne(i => i.Empresa)
                .HasForeignKey(i => i.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.LogsAlteracoes)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.HistoricosEstoquesProdutos)
                .WithOne(h => h.Empresa)
                .HasForeignKey(h => h.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.HistoricosEstoquesInsumos)
                .WithOne(h => h.Empresa)
                .HasForeignKey(h => h.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.HistoricosUsuariosAcessos)
                .WithOne(h => h.Empresa)
                .HasForeignKey(h => h.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Lotes)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
