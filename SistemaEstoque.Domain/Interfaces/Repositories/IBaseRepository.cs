namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, int empresaId);
        Task<IEnumerable<T>> GetAllAsync(int empresaId);
        Task AddAsync(T entity, int empresaId);
        Task AddRangeAsync(IEnumerable<T> entities, int empresaId);
        void Update(T entity, int empresaId);
        void Remove(T entity, int empresaId);
        void RemoveRange(IEnumerable<T> entities, int empresaId);
        Task SoftRemoveAsync(T entity, int empresaId);
        Task SoftRemoveRangeAsync(IEnumerable<T> entities, int empresaId);
    }
}
