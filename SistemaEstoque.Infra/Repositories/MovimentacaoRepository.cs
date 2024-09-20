using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly IRepositoryBase<Movimentacao> _repositoryBase;

        public MovimentacaoRepository(IRepositoryBase<Movimentacao> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(Movimentacao movimentacao)
        {
            await _repositoryBase.AddAsync(movimentacao);
        }

        public IQueryable<Movimentacao?> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public async Task<Movimentacao?> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }
    }
}
