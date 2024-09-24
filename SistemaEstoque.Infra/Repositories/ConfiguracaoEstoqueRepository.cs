using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class ConfiguracaoEstoqueRepository : RepositoryBase<ConfiguracaoEstoque>, IConfiguracaoEstoqueRepository
    {
        #region Constructor
        public ConfiguracaoEstoqueRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
            : base(context, ambienteUsuario)
        {
        }
        #endregion
    }
}
