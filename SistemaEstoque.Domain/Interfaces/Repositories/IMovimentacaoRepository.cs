using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoRepository
    {
        Task AddAsync(Movimentacao movimentacao, int idEmpresa);
        Task<IEnumerable<Movimentacao>> GetAllAsync(int idEmpresa);
        Task<Movimentacao> GetByIdAsync(int id);
    }
}
