using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoRepository
    {
        Task AddAsync(Movimentacao movimentacao);
        IQueryable<Movimentacao?> GetAll();
        Task<Movimentacao?> GetByIdAsync(int id);
    }
}
