using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Infra.Repositories;

public class AuditoriaUsuarioAcessoRepository : IAuditoriaUsuarioAcessoRepository
{
    private readonly SistemaEstoqueDbContext _context;
    private readonly DbSet<AuditoriaUsuarioAcesso> _dbSet;

    public AuditoriaUsuarioAcessoRepository(SistemaEstoqueDbContext context)
    {
        _context = context;
        _dbSet = context.Set<AuditoriaUsuarioAcesso>();
    }

    public async Task AddAsync(AuditoriaUsuarioAcesso auditoriaUsuarioAcesso)
    {
        await _dbSet.AddAsync(auditoriaUsuarioAcesso);
    }

    public IQueryable<AuditoriaUsuarioAcesso> GetAll(params string[]? includes)
    {
        return _dbSet
            .ApplyIncludes(includes)
            .WhereNotRemovido();
    }
}