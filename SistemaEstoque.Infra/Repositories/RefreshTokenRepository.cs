using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IRepositoryBase<RefreshToken> _repositoryBase;

    public RefreshTokenRepository(IRepositoryBase<RefreshToken> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }


    public async Task AddAsync(RefreshToken refreshToken, int empresaId)
    {
        await _repositoryBase.AddAsync(refreshToken, empresaId);
    }

    public async Task<RefreshToken> GetByTokenAsync(string token)
    {
        return await _repositoryBase.FindAsync(x => x.Token == token);
    }
}