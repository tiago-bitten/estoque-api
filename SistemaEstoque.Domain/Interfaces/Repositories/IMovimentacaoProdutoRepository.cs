using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoProdutoRepository
    {
        Task AddAsync(MovimentacaoProduto movimentacao, int idEmpresa);
        Task<IEnumerable<MovimentacaoProduto>> GetAllAsync(int idEmpresa);
        Task<MovimentacaoProduto> GetByIdAsync(int id);
    }
}
