using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Repositories;

public class MovimentacaoRepository : IMovimentacaoRepository
{
    #region Fields
    private readonly IRepositoryBase<Movimentacao> _repositoryBase;
    #endregion

    #region Constructor
    public MovimentacaoRepository(IRepositoryBase<Movimentacao> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }
    #endregion

    #region Methods

    #region AddAsync
    public async Task AddAsync(Movimentacao movimentacao)
    {
        await _repositoryBase.AddAsync(movimentacao);
    }
    #endregion

    #region GetAll
    public IQueryable<Movimentacao?> GetAll(params string[]? includes)
    {
        return _repositoryBase.GetAll(includes);
    }
    #endregion

    #region GetByIdAsync
    public async Task<Movimentacao?> GetByIdAsync(int id, params string[]? includes)
    {
        return await _repositoryBase.GetByIdAsync(id, includes);
    }
    #endregion

    #endregion
}