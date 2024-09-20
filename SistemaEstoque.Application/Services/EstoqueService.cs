using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class EstoqueService : ServiceBase<Estoque>, IEstoqueService
    {
        public EstoqueService(IEstoqueRepository repository)
            : base(repository)
        {
        }
    }
}
