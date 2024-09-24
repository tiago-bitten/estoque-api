using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Data;

namespace SistemaEstoque.Infra.Repositories;

public class ItemRepository : RepositoryBase<Item>, IItemRepository
{
    #region Constructor
    public ItemRepository(SistemaEstoqueDbContext context, IAmbienteUsuario ambienteUsuario)
        : base(context, ambienteUsuario)
    {
    }
    #endregion

    #region Methods

    #region GetAllProdutos
    public IQueryable<Item?> GetAllProdutos(params string[]? includes)
    {
        return GetAll(includes)
            .Where(x => x != null && x.Tipo == ETipoItem.Produto);
    }
    #endregion

    #region GetAllInsumos
    public IQueryable<Item?> GetAllInsumos(params string[]? includes)
    {
        return GetAll(includes)
            .Where(x => x != null && x.Tipo == ETipoItem.Insumo);
    }
    #endregion

    #endregion
}