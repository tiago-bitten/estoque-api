using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using SistemaEstoque.Infra.Extensions;

namespace SistemaEstoque.Infra.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(SistemaEstoqueDbContext context) 
           : base(context)
        {
        }

        public IQueryable<Item?> GetAllProdutos(params string[] includes)
        {
            return GetAll(includes)
                .Where(x => x != null && x.Tipo == ETipoItem.Produto);
        }

        public IQueryable<Item?> GetAllInsumos(params string[] includes)
        {
            return GetAll(includes)
                .Where(x => x != null && x.Tipo == ETipoItem.Insumo);
        }
    }
}
