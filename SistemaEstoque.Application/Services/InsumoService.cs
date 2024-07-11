using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class InsumoService : ServiceBase<Insumo>, IInsumoService
    {
        public InsumoService(IInsumoRepository repository)
            : base(repository)
        {
        }
    }
}
