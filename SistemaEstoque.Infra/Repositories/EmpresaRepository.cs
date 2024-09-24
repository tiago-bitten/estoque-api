using System.Linq.Expressions;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

// TODO: Refatorar esse repositório para usar RepoIdentificadorBase, se possível.
public class EmpresaRepository : IEmpresaRepository
{
    #region Fields
    private readonly SistemaEstoqueDbContext _context;
    #endregion

    #region Constructor
    public EmpresaRepository(SistemaEstoqueDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Methods

    #region AddAsync
    public async Task AddAsync(Empresa empresa)
    {
        await _context.AddAsync(empresa);
    }
    #endregion

    #region GetByIdAsync
    public async Task<Empresa?> GetByIdAsync(int id)
    {
        return await _context.Empresas.FindAsync(id);
    }
    #endregion

    #region FindAll
    public IQueryable<Empresa?> FindAll(Expression<Func<Empresa, bool>> predicate)
    {
        return _context.Empresas.Where(predicate);
    }
    #endregion

    #endregion
}
