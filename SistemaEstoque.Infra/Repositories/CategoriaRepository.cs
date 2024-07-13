using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SistemaEstoqueDbContext context) : base(context)
        {
        }

        public async override Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Set<Categoria>()
                .Include(c => c.Produtos)
                .Include(c => c.Empresa)
                .FirstOrDefaultAsync(c => c.Id == id && c.Removido == false);
        }

        public override IQueryable<Categoria> GetAll(int empresaId)
        {
            return _dbSet
                .Include(c => c.Produtos)
                .Include(c => c.Empresa)
                .Where(c => c.EmpresaId == empresaId && c.Removido == false)
                .AsQueryable();
        }
    }
}
