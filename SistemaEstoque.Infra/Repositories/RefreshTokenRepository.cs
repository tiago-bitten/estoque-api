using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IRepositoryBase<RefreshToken> _repositoryBase;
    private readonly SistemaEstoqueDbContext _context;

    public RefreshTokenRepository(
        IRepositoryBase<RefreshToken> repositoryBase,
        SistemaEstoqueDbContext context)
    {
        _repositoryBase = repositoryBase;
        _context = context;
    }


    public async Task AddAsync(RefreshToken refreshToken, int empresaId)
    {
        await _repositoryBase.AddAsync(refreshToken, empresaId);
    }
    
    public void Update(RefreshToken refreshToken)
    {
        _repositoryBase.Update(refreshToken);
    }

    public async Task<RefreshToken> GetByTokenAsync(string token)
    {
        return await _context.RefreshTokens
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task<RefreshToken> FindAsync(Expression<Func<RefreshToken, bool>> predicate)
    {
        return await _repositoryBase.FindAsync(predicate);
    }
}