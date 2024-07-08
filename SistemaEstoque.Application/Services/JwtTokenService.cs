using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class JwtTokenService : ITokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> GetEmpresaByTokenAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetUsuarioByTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
