using System.Linq.Expressions;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly SistemaEstoqueDbContext _context;

        public EmpresaRepository(SistemaEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Empresa empresa)
        {
            await _context.AddAsync(empresa);
        }

        public async Task<Empresa> GetByIdAsync(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public IQueryable<Empresa> FindAll(Expression<Func<Empresa, bool>> predicate)
        {
            return _context.Empresas.Where(predicate);
        }
    }
}
