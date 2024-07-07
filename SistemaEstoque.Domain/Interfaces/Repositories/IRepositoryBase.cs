using System.Linq.Expressions;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int empresaId);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity, int empresaId);
        void Update(T entity);
        void Remove(T entity);
        Task SoftRemoveAsync(T entity);
    }
}
