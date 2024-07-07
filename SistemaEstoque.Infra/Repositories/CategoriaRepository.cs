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

        public async Task<Categoria> GetByNomeAsync(string nome, int empresaId)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Nome.ToLower() == nome.ToLower() && c.EmpresaId == empresaId);
        }
    }
}
