namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task<bool> CommitAsync();
        Task RollbackAsync();
        Task BeginTransactionAsync();

        IEmpresaRepository Empresas { get; }
        ICategoriaRepository Categorias { get; }
        IUsuarioRepository Usuarios { get; }
        IItemRepository Items { get; }
        IFornecedorRepository Fornecedores { get; }
        IEstoqueRepository Estoques { get; }
        IRemesaLoteRepository RemesaLotes { get; }
        ILoteRepository Lotes { get; }
        IMovimentacaoRepository Movimentacoes { get; }
        IAuditoriaEntidadeRepository AuditoriaEntidades { get; }
        IPerfilAcessoRepository PerfisAcessos { get; }
        IPermissaoProdutoRepository PermissoesProdutos { get; }
        IPermissaoCategoriaRepository PermissoesCategorias { get; }
        IConfiguracaoEstoqueRepository ConfiguracoesEstoques { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        IAuditoriaUsuarioAcessoRepository AuditoriaUsuarioAcessos { get; }
    }
}
