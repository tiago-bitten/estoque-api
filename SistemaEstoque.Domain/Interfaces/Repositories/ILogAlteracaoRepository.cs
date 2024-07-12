using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface ILogAlteracaoRepository
    {
        Task LogAsync(LogAlteracao log, int empresaId);
        IQueryable<LogAlteracao> GetAllLogsFromItem(int itemId, string tabela, int empresaId);
    }
}
