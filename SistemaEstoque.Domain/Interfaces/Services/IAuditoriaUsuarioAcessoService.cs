using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Services;

public interface IAuditoriaUsuarioAcessoService
{
    Task AuditarAsync(Usuario usuario, bool acessoValido, bool senhaGlobal);
}