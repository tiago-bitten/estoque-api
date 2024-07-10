using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class InsumoRepository : RepositoryBase<Insumo>, IInsumoRepository
    {
        public InsumoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
