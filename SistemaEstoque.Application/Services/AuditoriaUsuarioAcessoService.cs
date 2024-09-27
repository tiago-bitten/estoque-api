using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services;

public class AuditoriaUsuarioAcessoService : IAuditoriaUsuarioAcessoService
{
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuario _ambienteUsuario;

    public AuditoriaUsuarioAcessoService(IUnitOfWork uow, IAmbienteUsuario ambienteUsuario)
    {
        _uow = uow;
        _ambienteUsuario = ambienteUsuario;
    }

    public async Task AuditarAsync(Usuario usuario, bool acessoValido, bool senhaGlobal)
    {
        var dataAcesso = DateTime.Now;
        var ip = _ambienteUsuario.GetIpAddress() ?? "NO IP";
        var userAgent = _ambienteUsuario.GetUserAgent() ?? "NO NAVEGADOR";

        var auditoria = new AuditoriaUsuarioAcesso(usuario.Id, dataAcesso, ip, userAgent, acessoValido, senhaGlobal);
        
        await _uow.regi
    }
}