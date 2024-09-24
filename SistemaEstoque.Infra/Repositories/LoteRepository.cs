using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

public class LoteRepository : RepositoryBase<Lote>, ILoteRepository
{
    #region Constructor
    public LoteRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
        : base(context, ambienteUsuario)
    {
    }
    #endregion
}