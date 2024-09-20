using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class LoteItemRepository : RepositoryBase<LoteItem>, ILoteItemRepository
    {
        public LoteItemRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
