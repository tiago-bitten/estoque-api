using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class LoteRepository : RepositoryBase<Lote>, ILoteRepository
    {
        public LoteRepository(SistemaEstoqueDbContext context):
            base(context)
        {
        }
    }
}
