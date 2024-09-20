using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class EstoqueRepository : RepositoryBase<Estoque>, IEstoqueInsumoRepository
    {
        public EstoqueRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
