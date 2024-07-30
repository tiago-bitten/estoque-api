using System.Security.Claims;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(Usuario usuario);
        Task<RefreshToken> GenerateRefreshToken(Usuario usuario);
        Task RevokeRefreshToken(string refreshToken);
        Task<Empresa> GetEmpresaByAccessTokenAsync(string token);
        Task<Usuario> GetUsuarioByAccessTokenAsync(string token);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
