using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services;

public class AmbienteUsuario : IAmbienteUsuario
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IServiceBase<Usuario> _usuarioService;
    private readonly IServiceBase<Empresa> _empresaService;

    public AmbienteUsuario(IHttpContextAccessor accessor, IServiceBase<Empresa> empresaService, IServiceBase<Usuario> usuarioService)
    {
        _accessor = accessor;
        _empresaService = empresaService;
        _usuarioService = usuarioService;
    }

    public async Task<Usuario> GetUsuarioAsync(params string[]? includes)
    {
        return await _usuarioService.GetAndEnsureExistsAsync(GetUsuarioId(), includes: includes);
    }

    public int GetUsuarioId()
    {
        var claim = _accessor.HttpContext?.User?.FindFirst("UsuarioId");

        if (claim == null || !int.TryParse(claim.Value, out var usuarioId))
            throw new Exception("Erro grave | linha 37 | SistemaEstoque.Application.Services.AmbienteUsuario.GetUsuarioId");

        return usuarioId;
        
    }

    public async Task<Empresa> GetTenantAsync()
    {
        return await _empresaService.GetAndEnsureExistsAsync(GetTenantId());
    }

    public int GetTenantId()
    {
        var claim = _accessor.HttpContext?.User?.FindFirst("TenantId");
        
        if (claim == null || !int.TryParse(claim.Value, out var tenantId))
            throw new Exception("Erro grave | linha 53 | SistemaEstoque.Application.Services.AmbienteUsuario.GetTenantId");
        
        return tenantId;
    }

    public bool Bloqueado()
    {
        var claim = _accessor.HttpContext?.User?.FindFirst("Bloqueado");
        
        if (claim == null || !bool.TryParse(claim.Value, out var bloqueado))
            throw new Exception("Erro grave | linha 60 | SistemaEstoque.Application.Services.AmbienteUsuario.Bloqueado");
        
        return bloqueado;
    }

    public bool Autenticado()
    {
        return _accessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
    
    public async Task<(Usuario Usuario, int TenantId)> GetUsuarioAndTenantAsync(params string[]? includes)
    {
        return (await GetUsuarioAsync(includes), GetTenantId());
    }
}