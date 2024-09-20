namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
        Task RollbackAsync();

        IEmpresaRepository Empresas { get; }
        ICategoriaRepository Categorias { get; }
        IUsuarioRepository Usuarios { get; }
        IProdutoRepository Produtos { get; }
        IFornecedorRepository Fornecedores { get; }
        IEstoqueRepository Estoques { get; }
        ILoteRepository Lotes { get; }
        ILoteProdutoRepository LotesProdutos { get; }
        ILoteInsumoRepository LotesInsumos { get; }
        IMovimentacaoProdutoRepository MovimentacoesProdutos { get; }
        IMovimentacaoInsumoRepository MovimentacoesInsumos { get; }
        IRegistroAlteracaoEntidadeRepository RegistrosAlteracoes { get; }
        IPerfilAcessoRepository PerfisAcessos { get; }
        IPermissaoProdutoRepository PermissoesProdutos { get; }
        IPermissaoCategoriaRepository PermissoesCategorias { get; }
        IConfiguracaoEstoqueRepository ConfiguracoesEstoques { get; }
        IRefreshTokenRepository RefreshTokens { get; }
    }
}
