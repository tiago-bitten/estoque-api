using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaEstoqueDbContext _context;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IInsumoRepository _insumoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEstoqueProdutoRepository _estoqueProdutoRepository;
        private readonly IEstoqueInsumoRepository _estoqueInsumoRepository;
        private readonly ILoteRepository _loteRepository;
        private readonly ILoteProdutoRepository _loteProdutoRepository;
        private readonly ILoteInsumoRepository _loteInsumoRepository;
        private readonly IMovimentacaoProdutoRepository _movimentacaoProdutoRepository;
        private readonly IMovimentacaoInsumoRepository _movimentacaoInsumoRepository;
        private readonly ILogAlteracaoRepository _logAlteracaoRepository;
        private readonly IPerfilAcessoRepository _perfilAcessoRepository;
        private readonly IPermissaoProdutoRepository _permissaoProdutoRepository;
        private readonly IPermissaoCategoriaRepository _permissaoCategoriaRepository;
        private readonly IConfiguracaoEstoqueRepository _configuracaoEstoqueRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public UnitOfWork(
            SistemaEstoqueDbContext context,
            IEmpresaRepository empresaRepository,
            ICategoriaRepository categoriaRepository,
            IUsuarioRepository usuarioRepository,
            IProdutoRepository produtoRepository,
            IInsumoRepository insumoRepository,
            IFornecedorRepository fornecedorRepository,
            IEstoqueProdutoRepository estoqueProdutoRepository,
            IEstoqueInsumoRepository estoqueInsumoRepository,
            ILoteRepository loteRepository,
            ILoteProdutoRepository loteProdutoRepository,
            ILoteInsumoRepository loteInsumoRepository,
            IMovimentacaoProdutoRepository movimentacaoProdutoRepository,
            IMovimentacaoInsumoRepository movimentacaoInsumoRepository,
            ILogAlteracaoRepository logAlteracaoRepository,
            IPerfilAcessoRepository perfilAcessoRepository,
            IPermissaoProdutoRepository permissaoProdutoRepository,
            IPermissaoCategoriaRepository permissaoCategoriaRepository,
            IConfiguracaoEstoqueRepository configuracaoEstoqueRepository, 
            IRefreshTokenRepository refreshTokenRepository)
        {
            _context = context;
            _empresaRepository = empresaRepository;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
            _insumoRepository = insumoRepository;
            _fornecedorRepository = fornecedorRepository;
            _estoqueProdutoRepository = estoqueProdutoRepository;
            _estoqueInsumoRepository = estoqueInsumoRepository;
            _movimentacaoProdutoRepository = movimentacaoProdutoRepository;
            _movimentacaoInsumoRepository = movimentacaoInsumoRepository;
            _loteRepository = loteRepository;
            _loteProdutoRepository = loteProdutoRepository;
            _loteInsumoRepository = loteInsumoRepository;
            _logAlteracaoRepository = logAlteracaoRepository;
            _perfilAcessoRepository = perfilAcessoRepository;
            _permissaoProdutoRepository = permissaoProdutoRepository;
            _permissaoCategoriaRepository = permissaoCategoriaRepository;
            _configuracaoEstoqueRepository = configuracaoEstoqueRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public IEmpresaRepository Empresas => _empresaRepository;
        public ICategoriaRepository Categorias => _categoriaRepository;
        public IUsuarioRepository Usuarios => _usuarioRepository;
        public IProdutoRepository Produtos => _produtoRepository;
        public IInsumoRepository Insumos => _insumoRepository;
        public IFornecedorRepository Fornecedores => _fornecedorRepository;
        public IEstoqueProdutoRepository EstoquesProdutos => _estoqueProdutoRepository;
        public IEstoqueInsumoRepository EstoquesInsumos => _estoqueInsumoRepository;
        public ILoteRepository Lotes => _loteRepository;
        public ILoteProdutoRepository LotesProdutos => _loteProdutoRepository;
        public ILoteInsumoRepository LotesInsumos => _loteInsumoRepository;
        public IMovimentacaoProdutoRepository MovimentacoesProdutos => _movimentacaoProdutoRepository;
        public IMovimentacaoInsumoRepository MovimentacoesInsumos => _movimentacaoInsumoRepository;
        public ILogAlteracaoRepository LogsAlteracoes => _logAlteracaoRepository;
        public IPerfilAcessoRepository PerfisAcessos => _perfilAcessoRepository;
        public IPermissaoProdutoRepository PermissoesProdutos => _permissaoProdutoRepository;
        public IPermissaoCategoriaRepository PermissoesCategorias => _permissaoCategoriaRepository;
        public IConfiguracaoEstoqueRepository ConfiguracoesEstoques => _configuracaoEstoqueRepository;
        public IRefreshTokenRepository RefreshTokens => _refreshTokenRepository;

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task RollbackAsync()
        {
            return Task.CompletedTask;
        }
    }
}
