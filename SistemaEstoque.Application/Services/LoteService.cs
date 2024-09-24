using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class LoteService : ServiceBase<Lote>, ILoteService
    {
        public LoteService(ILoteRepository repository)
            : base(repository)
        {
        }
    }
}
