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
        IInsumoRepository Insumos { get; }
        IFornecedorRepository Fornecedores { get; }
        IEstoqueProdutoRepository EstoquesProdutos { get; }
        IEstoqueInsumoRepository EstoquesInsumos { get; }
        ILoteRepository Lotes { get; }
        ILoteProdutoRepository LotesProdutos { get; }
        ILoteInsumoRepository LotesInsumos { get; }
        IMovimentacaoProdutoRepository MovimentacoesProdutos { get; }
        IMovimentacaoInsumoRepository MovimentacoesInsumos { get; }
        ILogAlteracaoRepository LogsAlteracoes { get; }
        IPerfilAcessoRepository PerfisAcessos { get; }
        IPermissaoProdutoRepository PermissoesProdutos { get; }
        IPermissaoCategoriaRepository PermissoesCategorias { get; }
    }
}
