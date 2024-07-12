using Microsoft.EntityFrameworkCore;
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

        public async override Task<IEnumerable<Insumo>> GetAllAsync(int empresaId)
        {
            return await _dbSet
                .Include(i => i.EstoqueInsumo)
                .Include(i => i.Categoria)
                .Include(i => i.LotesInsumos)
                .Include(i => i.MovimentacoesInsumos)
                .Where(i => i.EmpresaId == empresaId)
                .ToListAsync();
        }

        public async override Task<Insumo> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(i => i.EstoqueInsumo)
                .Include(i => i.Categoria)
                .Include(i => i.LotesInsumos)
                .Include(i => i.MovimentacoesInsumos)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
