using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        IQueryable<Item?> GetAllProdutos(params string[]? includes);
        IQueryable<Item?> GetAllInsumos(params string[]? includes);
    }
}
