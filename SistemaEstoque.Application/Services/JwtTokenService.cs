using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Email", usuario.Nome),
                new Claim("UsuarioId", usuario.Id.ToString()),
                new Claim("TenantId", usuario.EmpresaId.ToString())
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
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                UsuarioId = usuario.Id,
                ExpiraEm = DateTime.UtcNow.AddDays(7),
                IsRevogado = false,
                UltimaGeracao = DateTime.UtcNow
            };

            await _uow.RefreshTokens.AddAsync(refreshToken, usuario.EmpresaId);
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
            var principal = GetPrincipalFromToken(token);

            var empresaId = principal.Claims.FirstOrDefault(c => c.Type == "TenantId")?.Value;

            return await _uow.Empresas.GetByIdAsync(Convert.ToInt32(empresaId));
        }

        public async Task<Usuario> GetUsuarioByAccessTokenAsync(string token)
        {
            var principal = GetPrincipalFromToken(token);

            var usuarioId = principal.Claims.FirstOrDefault(c => c.Type == "UsuarioId")?.Value;

            return await _uow.Usuarios.GetByIdAsync(Convert.ToInt32(usuarioId));
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
            return principal;
        }
    }
}
