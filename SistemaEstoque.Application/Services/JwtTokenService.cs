using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _uow;

        public JwtTokenService(
            IConfiguration configuration,
            IUnitOfWork uow)
        {
            _configuration = configuration;
            _uow = uow;
        }

        public string GenerateAccessToken(Usuario usuario)
        {
            var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("Email", usuario.Nome),
                new("UsuarioId", usuario.Id.ToString()),
                new("TenantId", usuario.TenantId.ToString()),
                new("Bloqueado", usuario.AcessoBloqueado.ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpirationInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RefreshToken> GenerateRefreshTokenAsync(Usuario usuario)
        {
            var latestToken = await _uow.RefreshTokens.GetLatestValidTokenAsync(usuario.Id);

            if (latestToken is not null)
            {
                await RevokeRefreshTokenAsync(latestToken.Token, latestToken);
            }

            var refreshToken = RefreshToken.GenerateRefreshToken(usuario);
            await _uow.RefreshTokens.AddAsync(refreshToken);

            return refreshToken;
        }


        public async Task RevokeRefreshTokenAsync(string token, RefreshToken? refreshToken = null)
        {
            var tokenToRevoke = refreshToken ?? await _uow.RefreshTokens.GetByTokenAsync(token);
    
            if (tokenToRevoke is null)
                throw new InvalidOperationException("RefreshToken não encontrado para revogação.");

            tokenToRevoke.Revoke();
            _uow.RefreshTokens.Update(tokenToRevoke);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
            
            if (!(validatedToken is JwtSecurityToken jwtSecurityToken) ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
