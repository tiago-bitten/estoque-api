using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class LoteItemService : ServiceBase<LoteProduto>, ILoteItemService
    {
        public LoteItemService(ILoteItemRepository repository)
            : base(repository)
        {
        }
    }
}
