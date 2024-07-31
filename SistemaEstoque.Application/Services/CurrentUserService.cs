using Microsoft.AspNetCore.Http;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUnitOfWork _uow;
    
    public CurrentUserService(
        IHttpContextAccessor contextAccessor,
        IUnitOfWork uow)
    {
        _contextAccessor = contextAccessor;
        _uow = uow;
    }

    public async Task<Usuario> GetUsuario()
    {
        var usuarioId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UsuarioId")?.Value;
        return await _uow.Usuarios.GetByIdAsync(int.Parse(usuarioId));
    }

    public async Task<Empresa> GetEmpresa()
    {
        var empresaId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "TenantId")?.Value;
        return await _uow.Empresas.GetByIdAsync(int.Parse(empresaId));
    }
}