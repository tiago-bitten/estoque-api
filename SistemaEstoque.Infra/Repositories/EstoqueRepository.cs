using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class EstoqueRepository : RepositoryBase<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(SistemaEstoqueDbContext context) 
            : base(context)
        {
        }
    }
}
