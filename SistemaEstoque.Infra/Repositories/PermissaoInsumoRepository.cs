using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class PermissaoInsumoRepository : RepositoryBase<PermissaoInsumo>, IPermissaoInsumoRepository
    {
        public PermissaoInsumoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
