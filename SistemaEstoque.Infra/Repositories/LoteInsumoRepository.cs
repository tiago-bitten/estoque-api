using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class LoteInsumoRepository : RepositoryBase<LoteInsumo>, ILoteInsumoRepository
    {
        public LoteInsumoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
