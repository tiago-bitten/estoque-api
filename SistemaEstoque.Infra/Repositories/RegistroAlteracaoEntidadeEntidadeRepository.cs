using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Repositories;

public class RegistroAlteracaoEntidadeEntidadeRepository : IRegistroAlteracaoEntidadeRepository
{
    #region Fields
    private readonly IRepositoryBase<RegistroAlteracaoEntidade> _repository;
    #endregion
        
    #region Constructor
    public RegistroAlteracaoEntidadeEntidadeRepository(IRepositoryBase<RegistroAlteracaoEntidade> repository)
    {
        _repository = repository;
    }
    #endregion

    #region Methods
    
    #region GetAllLogsFromItem
    public IQueryable<RegistroAlteracaoEntidade?> GetAllLogsFromItem(int itemId, string tabela)
    {
        return _repository
            .FindAll(x => x.ItemId == itemId && x.Tabela == tabela, "Usuario");
    }
    #endregion

    #region LogAsync
    public async Task LogAsync(RegistroAlteracaoEntidade registro)
    {
        await _repository.AddAsync(registro);
    }
    #endregion
    
    #endregion
}