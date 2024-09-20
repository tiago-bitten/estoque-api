using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaEstoqueDbContext _context;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly ILoteRepository _loteRepository;
        private readonly ILoteItemRepository _loteItemRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IRegistroAlteracaoEntidadeRepository _registroAlteracaoEntidadeRepository;
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
            IItemRepository itemRepository,
            IFornecedorRepository fornecedorRepository,
            IEstoqueRepository estoqueRepository,
            ILoteRepository loteRepository,
            ILoteItemRepository loteItemRepository,
            IMovimentacaoRepository movimentacaoRepository,
            IRegistroAlteracaoEntidadeRepository registroAlteracaoEntidadeRepository,
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
            _itemRepository = itemRepository;
            _fornecedorRepository = fornecedorRepository;
            _estoqueRepository = estoqueRepository;
            _movimentacaoRepository = movimentacaoRepository;
            _loteRepository = loteRepository;
            _loteItemRepository = loteItemRepository;
            _registroAlteracaoEntidadeRepository = registroAlteracaoEntidadeRepository;
            _perfilAcessoRepository = perfilAcessoRepository;
            _permissaoProdutoRepository = permissaoProdutoRepository;
            _permissaoCategoriaRepository = permissaoCategoriaRepository;
            _configuracaoEstoqueRepository = configuracaoEstoqueRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public IEmpresaRepository Empresas => _empresaRepository;
        public ICategoriaRepository Categorias => _categoriaRepository;
        public IUsuarioRepository Usuarios => _usuarioRepository;
        public IItemRepository Items => _itemRepository;
        public IFornecedorRepository Fornecedores => _fornecedorRepository;
        public IEstoqueRepository Estoques => _estoqueRepository;
        public ILoteRepository Lotes => _loteRepository;
        public ILoteItemRepository LotesItems => _loteItemRepository;
        public IMovimentacaoRepository Movimentacoes => _movimentacaoRepository;
        public IRegistroAlteracaoEntidadeRepository RegistrosAlteracoes => _registroAlteracaoEntidadeRepository;
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
