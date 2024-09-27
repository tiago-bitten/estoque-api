using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories;

public interface IAuditoriaUsuarioAcessoRepository
{
    Task AddAsync(AuditoriaUsuarioAcesso auditoriaUsuarioAcesso);
    IQueryable<AuditoriaUsuarioAcesso> GetAll(params string[]? includes);
}