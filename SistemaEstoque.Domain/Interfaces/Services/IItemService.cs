using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IItemService : IServiceBase<Item>
    {
        Task EnsureNotExistsByNomeAsync(string nome, int tenantId);
    }
}
