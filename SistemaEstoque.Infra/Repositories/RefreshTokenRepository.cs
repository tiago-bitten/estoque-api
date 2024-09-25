using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    #region Fields
    private readonly SistemaEstoqueDbContext _context;
    private readonly DbSet<RefreshToken> _dbSet;
    #endregion

    #region Constructor
    public RefreshTokenRepository(
        SistemaEstoqueDbContext context)
    {
        _context = context;
        _dbSet = context.Set<RefreshToken>();
    }
    #endregion

    #region Methods

    #region AddAsync
    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _dbSet.AddAsync(refreshToken);
    }
    #endregion

    #region Update
    public void Update(RefreshToken refreshToken)
    {
        _dbSet.Update(refreshToken);
    }
    #endregion

    #region GetByTokenAsync
    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _dbSet
            .Where(x => x.Token == token && !x.Removido)
            .FirstOrDefaultAsync();
    }
    #endregion

    #region GetByUsuarioIdAsync
    public async Task<List<RefreshToken>> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _dbSet
            .Where(x => x.UsuarioId == usuarioId && !x.Removido)
            .ToListAsync();
    }
    #endregion

    #region GetLatestValidTokenAsync
    public async Task<RefreshToken?> GetLatestValidTokenAsync(int usuarioId)
    {
        return await _dbSet
            .Where(x => x.UsuarioId == usuarioId && !x.Revogado && !x.Removido)
            .FirstOrDefaultAsync();
    }
    #endregion
    
    #region FindAsync
    public async Task<RefreshToken?> FindAsync(Expression<Func<RefreshToken, bool>> predicate)
    {
        return await _dbSet
            .Where(predicate)
            .FirstOrDefaultAsync();
    }
    #endregion

    #endregion
}