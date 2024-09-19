using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaEstoque.Infra.EntitiesConfig.Utils
{
    public static class EfCoreExtensions
    {
        public static PropertyBuilder<TEnum> HasEnumConversion<TEnum>(this PropertyBuilder<TEnum> builder)
            where TEnum : struct, Enum
        {
            return builder.HasConversion(
                v => v.ToString(),
                v => (TEnum)Enum.Parse(typeof(TEnum), v) 
            );
        }
    }
}