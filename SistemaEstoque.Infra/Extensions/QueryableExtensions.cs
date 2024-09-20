using Microsoft.EntityFrameworkCore;

namespace SistemaEstoque.Infra.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyIncludes<T>(this IQueryable<T> query, params string[]? includes) where T : class
        {
            return includes == null ? query : includes.Aggregate(query, (current, include) => current.Include(include));
        }
    }
}