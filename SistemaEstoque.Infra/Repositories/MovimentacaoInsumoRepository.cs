using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class MovimentacaoInsumoRepository : RepositoryBase<MovimentoInsumo>, IMovimentacaoInsumoRepository
    {
        public MovimentacaoInsumoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
