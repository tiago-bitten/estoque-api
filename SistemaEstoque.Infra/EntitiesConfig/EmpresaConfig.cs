using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class EmpresaConfig : IdentificadorBaseConfig<Empresa>
    {
        public override void Configure(EntityTypeBuilder<Empresa> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("empresas");

            builder.Property(e => e.Nome)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(e => e.CpfCnpj)
                .HasColumnType($"{TipoColunaConstants.Varchar}(14)")
                .HasColumnName("cpf_cnpj")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(e => e.TipoEmpresa)
                .HasColumnType(TipoColunaConstants.Text)
                .HasColumnName("tipo_empresa")
                .HasConversion<ETipoEmpresa>()
                .IsRequired();

            builder.Property(e => e.Telefone)
                .HasColumnType($"{TipoColunaConstants.Varchar}(15)")
                .HasColumnName("telefone")
                .IsRequired();

            builder.Property(e => e.Endereco)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("endereco")
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("cidade")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnType($"{TipoColunaConstants.Varchar}(2)")
                .HasColumnName("estado")
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnType($"{TipoColunaConstants.Varchar}(8)")
                .HasColumnName("cep")
                .IsRequired();

            builder.Property(e => e.ProprietarioId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("proprietario_id");

            builder.HasOne(e => e.ConfiguracaoEstoque)
                .WithOne(c => c.Empresa)
                .HasForeignKey<ConfiguracaoEstoque>(c => c.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Proprietario)
                .WithMany(p => p.Empresas)
                .HasForeignKey(e => e.ProprietarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Usuarios)
                .WithOne(u => u.Empresa)
                .HasForeignKey(u => u.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Categorias)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Produtos)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        
            builder.HasMany(e => e.Fornecedores)
                .WithOne(f => f.Empresa)
                .HasForeignKey(f => f.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Lotes)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Movimentacoes)
                .WithOne(m => m.Empresa)
                .HasForeignKey(m => m.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Estoques)
                .WithOne(es => es.Empresa)
                .HasForeignKey(es => es.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Insumos)
                .WithOne(i => i.Empresa)
                .HasForeignKey(i => i.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.LogsAlteracoes)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.HistoricosEstoquesProdutos)
                .WithOne(h => h.Empresa)
                .HasForeignKey(h => h.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.HistoricosUsuariosAcessos)
                .WithOne(h => h.Empresa)
                .HasForeignKey(h => h.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Lotes)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.PerfisAcessos)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.PermissoesProdutos)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.PermissoesCategorias)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.PermissoesInsumos)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.RefreshTokens)
                .WithOne(x => x.Empresa)
                .HasForeignKey(x => x.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
