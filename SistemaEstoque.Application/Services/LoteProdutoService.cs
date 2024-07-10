using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class LoteProdutoService : ServiceBase<LoteProduto>, ILoteProdutoService
    {
        public LoteProdutoService(ILoteProdutoRepository repository)
            : base(repository)
        {
        }
    }
}
