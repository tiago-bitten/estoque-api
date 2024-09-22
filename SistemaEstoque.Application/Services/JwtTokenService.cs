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
                new("TenantId", usuario.TenantId.ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(Int32.Parse(_configuration["Jwt:ExpirationInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RefreshToken> GenerateRefreshToken(Usuario usuario)
        {
            var existingToken = await _uow.RefreshTokens
                .FindAsync(rt => rt.UsuarioId == usuario.Id && !rt.IsRevogado);

            RefreshToken refreshToken;

            if (existingToken is null)
            {
                refreshToken = new RefreshToken
                {
                    Token = GenerateSecureToken(),
                    UsuarioId = usuario.Id,
                    ExpiraEm = DateTime.UtcNow.AddDays(7),
                    IsRevogado = false,
                    UltimaGeracao = DateTime.UtcNow
                };
                
                refreshToken.TenantId = usuario.TenantId;

                await _uow.RefreshTokens.AddAsync(refreshToken);
            }
            else
            {
                existingToken.Token = GenerateSecureToken();
                existingToken.ExpiraEm = DateTime.UtcNow.AddDays(7);
                existingToken.IsRevogado = false;
                existingToken.UltimaGeracao = DateTime.UtcNow;

                _uow.RefreshTokens.Update(existingToken);
                refreshToken = existingToken;
            }

            await _uow.CommitAsync();

            return refreshToken;
        }

        public async Task RevokeRefreshToken(string refreshToken)
        {
            var token = await _uow.RefreshTokens.GetByTokenAsync(refreshToken);
            if (token != null)
            {
                token.IsRevogado = true;
                _uow.RefreshTokens.Update(token);
            }
        }

        public async Task<Empresa> GetEmpresaByAccessTokenAsync(string token)
        {
            var principal = GetPrincipalFromExpiredToken(token);

            var empresaId = principal.Claims.FirstOrDefault(c => c.Type == "TenantId")?.Value;

            return await _uow.Empresas.GetByIdAsync(Convert.ToInt32(empresaId));
        }

        public async Task<Usuario> GetUsuarioByAccessTokenAsync(string token)
        {
            var principal = GetPrincipalFromExpiredToken(token);

            var usuarioId = principal.Claims.FirstOrDefault(c => c.Type == "UsuarioId")?.Value;

            return await _uow.Usuarios.GetByIdAsync(Convert.ToInt32(usuarioId));
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

        public bool ValidateExpiredAccessToken(string token)
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

            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var exp = principal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
                    var expirationDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp)).UtcDateTime;
                    return expirationDate < DateTime.UtcNow;
                }
                throw new SecurityTokenException("Invalid token");
            }
            catch (SecurityTokenException)
            {
                return false;
            }
        }

        private string GenerateSecureToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
    }
}
