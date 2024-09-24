using System.Linq.Expressions;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    #region Fields
    private readonly IRepositoryBase<RefreshToken> _repositoryBase;
    private readonly SistemaEstoqueDbContext _context;
    #endregion

    #region Constructor
    public RefreshTokenRepository(
        IRepositoryBase<RefreshToken> repositoryBase,
        SistemaEstoqueDbContext context)
    {
        _repositoryBase = repositoryBase;
        _context = context;
    }
    #endregion

    #region Methods

    #region AddAsync
    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _repositoryBase.AddAsync(refreshToken);
    }
    #endregion

    #region Update
    public void Update(RefreshToken refreshToken)
    {
        _repositoryBase.Update(refreshToken);
    }
    #endregion

    #region GetByTokenAsync
    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _repositoryBase
            .FindAsync(x => x.Token == token, "Usuario");
    }
    #endregion

    #region FindAsync
    public async Task<RefreshToken?> FindAsync(Expression<Func<RefreshToken, bool>> predicate)
    {
        return await _repositoryBase.FindAsync(predicate, "Usuario");
    }
    #endregion

    #endregion
}