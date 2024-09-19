﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.EntitiesConfig.Abstracoes;
using SistemaEstoque.Infra.EntitiesConfig.Utils;

namespace SistemaEstoque.Infra.EntitiesConfig
{
    public class LoteItemConfig : IdentificadorTenantConfig<LoteItem>
    {
        public override void Configure(EntityTypeBuilder<LoteItem> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("lotes_itens");

            builder.Property(l => l.DataFabricacao)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data_fabricacao")
                .IsRequired();

            builder.Property(l => l.DataValidade)
                .HasColumnType(TipoColunaConstants.TimestampWithTimeZone)
                .HasColumnName("data_validade")
                .IsRequired();

            builder.Property(l => l.Quantidade)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(l => l.ItemId)
                .HasColumnType(TipoColunaConstants.Int)
                .HasColumnName("item_id")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnType(TipoColunaConstants.Text)
                .HasConversion<ETipoItem>();

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.LoteItems)
                .HasForeignKey(l => l.TenantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}