using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Infra.Repositories
{
    public class RemesaLoteRepository : RepositoryBase<RemessaLote>, IRemesaLoteRepository
    {
        #region Constructor
        public RemesaLoteRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
            : base(context, ambienteUsuario)
        {
        }
        #endregion
    }
}
