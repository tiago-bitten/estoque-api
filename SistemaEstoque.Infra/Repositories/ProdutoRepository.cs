using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(SistemaEstoqueDbContext context) 
           : base(context)
        {
        }

        public override async Task<Produto> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.EstoqueProduto)
                .Include(p => p.LotesProdutos)
                .Include(p => p.MovimentacoesProdutos)
                .FirstOrDefaultAsync(p => p.Id == id);  
        }

        public override IQueryable<Produto> GetAll(int empresaId)
        {
            return _dbSet
                .Include(p => p.Categoria)
                .Include(p => p.EstoqueProduto)
                .Include(p => p.LotesProdutos)
                .Include(p => p.MovimentacoesProdutos)
                .Where(p => p.EmpresaId == empresaId)
                .AsQueryable();
        }
    }
}
