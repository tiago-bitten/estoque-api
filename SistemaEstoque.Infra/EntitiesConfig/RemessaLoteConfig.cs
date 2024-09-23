using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class RemessaLoteConfig : IdentificadorTenantConfig<RemessaLote>
    {
        public override void Configure(EntityTypeBuilder<RemessaLote> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("remessas_lotes");

            builder.Property(l => l.Descricao)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("descricao")
                .IsRequired();

            builder.Property(l => l.Codigo)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("codigo")
                .IsRequired();

            builder.Property(l => l.CodigoBarras)
                .HasColumnType(TipoColunaConstants.VarcharDefault)
                .HasColumnName("codigo_barras")
                .IsRequired();

            builder.Property(l => l.FornecedorId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("fornecedor_id")
                .IsRequired();

            builder.Property(l => l.DataRecebimento)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data_recebimento")
                .IsRequired();

            builder.Property(l => l.UsuarioRecebimentoId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("usuario_recebimento_id")
                .IsRequired();

            builder.HasOne(l => l.Fornecedor)
                .WithMany(f => f.Lotes)
                .HasForeignKey(l => l.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.LoteItems)
                .WithOne(x => x.RemessaLote)
                .HasForeignKey(x => x.LoteId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.UsuarioRecebimento)
                .WithMany(u => u.Lotes)
                .HasForeignKey(l => l.UsuarioRecebimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.Lotes)
                .HasForeignKey(l => l.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
