using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        Task RollbackAsync();

        ICategoriaRepository Categorias { get; }
        IUsuarioRepository Usuarios { get; }
        IProdutoRepository Produtos { get; }
        IFornecedorRepository Fornecedores { get; }
    }
}
