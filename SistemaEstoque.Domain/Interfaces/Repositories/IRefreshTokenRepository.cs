using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken, int empresaId);
    Task<RefreshToken> GetByTokenAsync(string token);
}