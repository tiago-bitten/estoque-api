using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    #region Constructor
    public UsuarioRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
        : base(context, ambienteUsuario)
    {
    }
    #endregion

    #region Methods

    #region GetByEmailAsync
    public async Task<Usuario?> GetByEmailAsync(string email, params string[]? includes)
    {
        return await FindAsync(u => u.Email == email, includes);
    }
    #endregion

    #endregion
}
