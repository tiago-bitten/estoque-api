using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : IdentificadorBase
    {
        Task<bool> ExistsAsync(int id, bool includeDeleted = false);
        Task EnsureExistsAsync(int id, bool includeDeleted = false);
        Task<T> GetAndEnsureExistsAsync(int id, bool includeDeleted = false, params string[]? includes);
    }
}
