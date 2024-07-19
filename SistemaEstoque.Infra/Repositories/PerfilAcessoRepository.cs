using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class PerfilAcessoRepository : RepositoryBase<PerfilAcesso>, IPerfilAcessoRepository
    {
        public PerfilAcessoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
