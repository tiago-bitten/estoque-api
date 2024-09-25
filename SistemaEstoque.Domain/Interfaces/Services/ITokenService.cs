using System.Security.Claims;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(Usuario usuario);
        Task<RefreshToken> GenerateRefreshTokenAsync(Usuario usuario);
        Task RevokeRefreshTokenAsync(string token, RefreshToken? refreshToken = null);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
