using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Shared.Extensions;

public static class UnitOfWorkExtensions
{
    public static async Task CommitAndAuditAsync<T>(
        this IUnitOfWork unitOfWork, 
        T entidade, 
        string tabela, 
        IServiceManager serviceManager) where T : IdentificadorBase
    {
        await unitOfWork.CommitAsync().ContinueWith(async commitTask =>
        {
            if (commitTask.IsCompletedSuccessfully)
            {
                await serviceManager.AuditoriaEntidades.AuditarAdicaoAsync(entidade, tabela);
            }
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
    }
}
