using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.Infra.Repositories
{
    public class RemesaLoteRepository : RepositoryBase<RemessaLote>, IRemesaLoteRepository
    {
        public RemesaLoteRepository(SistemaEstoqueDbContext context):
            base(context)
        {
        }
    }
}
