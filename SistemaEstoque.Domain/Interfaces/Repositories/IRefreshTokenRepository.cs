using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken, int empresaId);
    void Update(RefreshToken refreshToken);
    Task<RefreshToken> GetByTokenAsync(string token);
}