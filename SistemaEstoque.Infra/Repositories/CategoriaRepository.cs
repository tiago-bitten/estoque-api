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

        public async override Task<IEnumerable<Categoria>> GetAllAsync(int empresaId)
        {
            return await _context.Set<Categoria>()
                .Include(c => c.Produtos)
                .Include(c => c.Empresa)
                .Where(c => c.EmpresaId == empresaId && c.Removido == false)
                .ToListAsync();
        }

        public async Task<Categoria> GetByNomeAsync(string nome, int empresaId)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Nome.ToLower() == nome.ToLower() && c.EmpresaId == empresaId);
        }
    }
}
