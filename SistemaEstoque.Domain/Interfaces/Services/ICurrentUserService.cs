using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Services;

public interface ICurrentUserService
{
    Task<Usuario> GetUsuario();
    Task<Empresa> GetEmpresa();
}