using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class LoteItemRepository : RepositoryBase<LoteItem>, ILoteProdutoRepository
    {
        public LoteItemRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
