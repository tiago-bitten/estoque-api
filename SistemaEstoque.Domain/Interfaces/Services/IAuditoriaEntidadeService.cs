using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IAuditoriaEntidadeService
    {
        Task AuditarAdicaoAsync<T>(T entidade, string tabela) where T : IdentificadorBase;
        
        Task LogAsync(
            string? dadosAntigos,
            string? dadosNovos,
            string tabela,
            int itemId,
            int quantidade,
            int usuarioId,
            ETipoAlteracao tipo);
    }
}
