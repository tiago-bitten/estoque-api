using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class EstoqueInsumoRepository : RepositoryBase<EstoqueInsumo>, IEstoqueInsumoRepository
    {
        public EstoqueInsumoRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }

        public override IQueryable<EstoqueInsumo> GetAll(int empresaId)
        {
            return _dbSet
                .Include(x => x.Insumo)
                    .ThenInclude(x => x.Categoria)
                .Where(x => x.EmpresaId == empresaId && x.Removido == false);
        }

        public override async Task<EstoqueInsumo> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Insumo)
                    .ThenInclude(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
