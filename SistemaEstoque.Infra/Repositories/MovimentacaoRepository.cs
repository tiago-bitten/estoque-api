using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoProdutoRepository
    {
        private readonly IRepositoryBase<Movimentacao> _repositoryBase;

        public MovimentacaoRepository(IRepositoryBase<Movimentacao> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(Movimentacao movimentacao, int idEmpresa)
        {
            await _repositoryBase.AddAsync(movimentacao, idEmpresa);
        }

        public IQueryable<Movimentacao> GetAll(int idEmpresa)
        {
            return _repositoryBase.GetAll(idEmpresa);
        }

        public async Task<Movimentacao> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }
    }
}
