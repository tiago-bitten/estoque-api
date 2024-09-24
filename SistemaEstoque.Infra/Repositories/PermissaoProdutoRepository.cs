using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class PermissaoProdutoRepository : RepositoryBase<PermissaoProduto>, IPermissaoProdutoRepository
    {
        #region Constructor
        public PermissaoProdutoRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
            : base(context, ambienteUsuario)
        {
        }
        #endregion
    }
}
