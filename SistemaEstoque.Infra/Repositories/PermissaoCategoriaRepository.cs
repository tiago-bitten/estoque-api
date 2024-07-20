using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class PermissaoCategoriaRepository : RepositoryBase<PermissaoCategoria>, IPermissaoCategoriaRepository
    {
        public PermissaoCategoriaRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
