using System.Linq.Expressions;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Shared.Extensions;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> AddGlobalFilter<T>(this Expression<Func<T, bool>>? originalExpression, int tenantId)
        where T : IdentificadorTenant
    {
        Expression<Func<T, bool>> tenantAndRemovidoFilter = x => x.TenantId == tenantId && !x.Removido;

        var combined = originalExpression == null
            ? tenantAndRemovidoFilter
            : originalExpression.And(tenantAndRemovidoFilter);

        return combined;
    }

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var body = Expression.AndAlso(
            Expression.Invoke(expr1, parameter),
            Expression.Invoke(expr2, parameter));

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}