using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Shared.Util;

namespace SistemaEstoque.Shared.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyIncludes<T>(this IQueryable<T> query, params string[]? includes) where T : class
    {
        return includes == null ? query : includes.Aggregate(query, (current, include) => current.Include(include));
    }

    public static IQueryable<T> WhereNotRemovido<T>(this IQueryable<T> query,
        Expression<Func<T, bool>>? anotherCondition = null) where T : IdentificadorBase
    {
        var queryable = query.Where(x => !x.Removido);
            
        return anotherCondition == null ? queryable : queryable.Where(anotherCondition);
    }

    public static IQueryable<T> GlobalWhere<T>(this IQueryable<T> query, int tenantId, Expression<Func<T, bool>>? anotherCondition = null) where T : IdentificadorTenant
    {
        var queryable = query.Where(x => x.TenantId == tenantId);

        return queryable.WhereNotRemovido(anotherCondition);
    }
        
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int page, int size) where T : class
    {
        var total = await query.CountAsync();
        var data = await query.Skip(page * size).Take(size).ToListAsync();

        return new PagedResult<T>
        {
            Data = data,
            Page = page,
            Size = size,
            Total = total,
            HasNext = (page + 1) * size < total,
            HasPrevious = page > 0
        };
    }

}