using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        public FornecedorService(IFornecedorRepository repository)
            : base(repository)
        {
        }
    }
}
