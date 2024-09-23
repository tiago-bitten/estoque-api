using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class ItemService : ServiceBase<Item>, IItemService
    {
        public ItemService(IItemRepository repository)
            : base(repository)
        {
        }

        public async Task EnsureNotExistsByNomeAsync(string nome, int tenantId)
        {
            var exists = await Repository
                .AnyAsync(x => x.Nome == nome && x.TenantId == tenantId && !x.Removido);
            
            if (exists)
                throw new Exception("Já existe");
        }
    }
}
