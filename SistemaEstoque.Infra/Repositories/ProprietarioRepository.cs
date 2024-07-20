using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class ProprietarioRepository : RepositoryBase<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(SistemaEstoqueDbContext context)
            : base(context)
        {
        }
    }
}
