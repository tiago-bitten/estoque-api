using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoProdutoRepository
    {
        Task AddAsync(MovimentacaoProduto movimentacao, int idEmpresa);
        IQueryable<MovimentacaoProduto> GetAll(int idEmpresa);
        Task<MovimentacaoProduto> GetByIdAsync(int id);
    }
}
