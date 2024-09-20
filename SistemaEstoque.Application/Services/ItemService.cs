using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class ItemService : ServiceBase<Produto>, IItemService
    {
        public ItemService(IItemRepository repository)
            : base(repository)
        {
        }
    }
}
