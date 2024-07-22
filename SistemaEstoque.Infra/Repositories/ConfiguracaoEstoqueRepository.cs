using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class ConfiguracaoEstoqueRepository : RepositoryBase<ConfiguracaoEstoque>, IConfiguracaoEstoqueRepository
    {
        public ConfiguracaoEstoqueRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
