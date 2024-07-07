using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository)
            : base(repository)
        {
        }
    }
}
