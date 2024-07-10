using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class LoteProdutoRepository : RepositoryBase<LoteProduto>, ILoteProdutoRepository
    {
        public LoteProdutoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
