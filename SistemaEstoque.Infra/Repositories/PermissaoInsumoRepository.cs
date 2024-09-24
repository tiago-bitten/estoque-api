using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class PermissaoInsumoRepository : RepositoryBase<PermissaoInsumo>, IPermissaoInsumoRepository
    {
        #region Constructor
        public PermissaoInsumoRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
            : base(context, ambienteUsuario)
        {
        }
        #endregion
    }
}
