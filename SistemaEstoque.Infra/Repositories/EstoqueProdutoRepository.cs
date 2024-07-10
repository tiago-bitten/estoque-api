using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class EstoqueProdutoRepository : RepositoryBase<EstoqueProduto>, IEstoqueProdutoRepository
    {
        public EstoqueProdutoRepository(SistemaEstoqueDbContext context) 
            : base(context)
        {
        }
    }
}
