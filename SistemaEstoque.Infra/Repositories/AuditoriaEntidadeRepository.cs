using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Infra.Repositories;

public class AuditoriaEntidadeRepository : IAuditoriaEntidadeRepository
{
    #region Fields
    private readonly IRepositoryBase<AuditoriaEntidade> _repository;
    private readonly IAmbienteUsuario _ambienteUsuario;
    #endregion
        
    #region Constructor
    public AuditoriaEntidadeRepository(IRepositoryBase<AuditoriaEntidade> repository, IAmbienteUsuario ambienteUsuario)
    {
        _repository = repository;
        _ambienteUsuario = ambienteUsuario;
    }
    #endregion

    #region Methods
    
    #region GetAllLogsFromItem
    public IQueryable<AuditoriaEntidade?> GetAllLogsFromItem(int entidadeId, string tabela)
    {
        return _repository
            .FindAll(x => x.EntidadeId == entidadeId && x.Tabela == tabela, "Usuario");
    }
    #endregion

    #region LogAsync
    public async Task AddAsync(AuditoriaEntidade registro)
    {
        registro.UsuarioId = _ambienteUsuario.GetUsuarioId();
        await _repository.AddAsync(registro);
    }
    #endregion
    
    #endregion
}