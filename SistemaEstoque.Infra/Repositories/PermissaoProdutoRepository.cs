using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class PermissaoProdutoRepository : RepositoryBase<PermissaoProduto>, IPermissaoProdutoRepository
    {
        public PermissaoProdutoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
