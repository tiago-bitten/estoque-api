using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
        Task<Empresa> GetEmpresaByTokenAsync(string token);
        Task<Usuario> GetUsuarioByTokenAsync(string token);
    }
}
