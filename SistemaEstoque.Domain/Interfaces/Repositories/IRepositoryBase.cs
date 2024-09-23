using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, params string[]? includes);
        IQueryable<T?> GetAll(params string[]? includes);
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate, params string[]? includes);
        IQueryable<T?> FindAll(Expression<Func<T, bool>> predicate, params string[]? includes);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void SoftRemove(T entity);
        void SoftRemoveRange(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, params string[]? includes);
    }
}
