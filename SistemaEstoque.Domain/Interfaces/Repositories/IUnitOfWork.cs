namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        Task RollbackAsync();

        ICategoriaRepository Categorias { get; }
        IUsuarioRepository Usuarios { get; }
        IProdutoRepository Produtos { get; }
        IFornecedorRepository Fornecedores { get; }
        IEstoqueRepository Estoques { get; }
        ILoteRepository Lotes { get; }
        IMovimentacaoRepository Movimentacoes { get; }
        ILogAlteracaoRepository LogsAlteracoes { get; }
    }
}
