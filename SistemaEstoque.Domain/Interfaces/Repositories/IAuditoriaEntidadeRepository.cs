using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IAuditoriaEntidadeRepository
    {
        Task AddAsync(AuditoriaEntidade registro);
        IQueryable<AuditoriaEntidade?> GetAllLogsFromItem(int itemId, string tabela);
    }
}
