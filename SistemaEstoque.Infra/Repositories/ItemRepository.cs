using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IProdutoRepository
    {
        public ItemRepository(SistemaEstoqueDbContext context) 
           : base(context)
        {
        }
    }
}
