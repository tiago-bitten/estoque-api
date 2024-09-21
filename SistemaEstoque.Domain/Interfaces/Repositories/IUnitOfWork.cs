namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        Task RollbackAsync();

        IEmpresaRepository Empresas { get; }
        ICategoriaRepository Categorias { get; }
        IUsuarioRepository Usuarios { get; }
        IItemRepository Items { get; }
        IFornecedorRepository Fornecedores { get; }
        IEstoqueRepository Estoques { get; }
        IRemesaLoteRepository RemesaLotes { get; }
        ILoteRepository Lotes { get; }
        IMovimentacaoRepository Movimentacoes { get; }
        IRegistroAlteracaoEntidadeRepository RegistrosAlteracoes { get; }
        IPerfilAcessoRepository PerfisAcessos { get; }
        IPermissaoProdutoRepository PermissoesProdutos { get; }
        IPermissaoCategoriaRepository PermissoesCategorias { get; }
        IConfiguracaoEstoqueRepository ConfiguracoesEstoques { get; }
        IRefreshTokenRepository RefreshTokens { get; }
    }
}
