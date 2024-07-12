using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll(int empresaId);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity, int empresaId);
        void Update(T entity);
        void Remove(T entity);
        Task SoftRemoveAsync(T entity);
    }
}
