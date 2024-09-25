using System.Linq.Expressions;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken);
    void Update(RefreshToken refreshToken);
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<List<RefreshToken>> GetByUsuarioIdAsync(int usuarioId);
    Task<RefreshToken?> GetLatestValidTokenAsync(int usuarioId);
    Task<RefreshToken?> FindAsync(Expression<Func<RefreshToken, bool>> predicate);
}