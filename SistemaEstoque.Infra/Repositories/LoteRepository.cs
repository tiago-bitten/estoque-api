using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.Infra.Repositories
{
    public class LoteRepository : RepositoryBase<Lote>, ILoteRepository
    {
        public LoteRepository(SistemaEstoqueDbContext context):
            base(context)
        {
        }

        public override IQueryable<Lote> GetAll(int empresaId)
        {
            return _dbSet
                .Include(x => x.LotesInsumos)
                    .ThenInclude(x => x.Insumo)
                        .ThenInclude(x => x.Categoria)
                .Include(x => x.LotesProdutos)
                    .ThenInclude(x => x.Produto)
                        .ThenInclude(x => x.Categoria)
                .Include(x => x.UsuarioRecebimento)
                .Include(x => x.Fornecedor)
                .Where(x => x.EmpresaId == empresaId);
        }

        public override async Task<Lote> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.LotesInsumos)
                    .ThenInclude(x => x.Insumo)
                        .ThenInclude(x => x.Categoria)
                .Include(x => x.LotesProdutos)
                    .ThenInclude(x => x.Produto)
                        .ThenInclude(x => x.Categoria)
                .Include(x => x.UsuarioRecebimento)
                .Include(x => x.Fornecedor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
