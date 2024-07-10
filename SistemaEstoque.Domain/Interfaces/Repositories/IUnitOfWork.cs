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
        IEstoqueProdutoRepository EstoquesProdutos { get; }
        ILoteProdutoRepository LotesProdutos { get; }
        IMovimentacaoProdutoRepository MovimentacoesProdutos { get; }
        ILogAlteracaoRepository LogsAlteracoes { get; }
    }
}
