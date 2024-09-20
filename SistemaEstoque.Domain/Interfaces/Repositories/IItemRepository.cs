using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
    }
}
