using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class EstoqueProdutoRepository : RepositoryBase<EstoqueProduto>, IEstoqueProdutoRepository
    {
        public EstoqueProdutoRepository(SistemaEstoqueDbContext context) 
            : base(context)
        {
        }

        public override Task<EstoqueProduto> GetByIdAsync(int id)
        {
            return _dbSet
                .Include(e => e.Empresa)
                .Include(e => e.Produto)
                    .ThenInclude(p => p.Categoria)
                .Include(e => e.HistoricosEstoquesProdutos)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override IQueryable<EstoqueProduto> GetAll(int empresaId)
        {
            return _dbSet
                .Where(e => e.EmpresaId == empresaId && e.Removido == false)
                .Include(e => e.Empresa)
                .Include(e => e.Produto)
                    .ThenInclude(p => p.Categoria)
                .Include(e => e.HistoricosEstoquesProdutos)
                .AsQueryable();
        }
    }
}
