using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class MovimentacaoInsumoRepository : RepositoryBase<MovimentacaoInsumo>, IMovimentacaoInsumoRepository
    {
        public MovimentacaoInsumoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
