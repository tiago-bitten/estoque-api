using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface ILogAlteracaoRepository
    {
        Task LogAsync(RegistroAlteracaoEntidade registro, int empresaId);
        IQueryable<RegistroAlteracaoEntidade> GetAllLogsFromItem(int itemId, string tabela, int empresaId);
    }
}
