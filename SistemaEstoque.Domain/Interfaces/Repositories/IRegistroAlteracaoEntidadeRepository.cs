using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IRegistroAlteracaoEntidadeRepository
    {
        Task LogAsync(RegistroAlteracaoEntidade registro);
        IQueryable<RegistroAlteracaoEntidade?> GetAllLogsFromItem(int itemId, string tabela);
    }
}
