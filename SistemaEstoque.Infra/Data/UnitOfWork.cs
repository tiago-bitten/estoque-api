using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Repositories;
using System.Threading.Tasks;

namespace SistemaEstoque.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaEstoqueDbContext _context;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IInsumoRepository _insumoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEstoqueProdutoRepository _estoqueProdutoRepository;
        private readonly IEstoqueInsumoRepository _estoqueInsumoRepository;
        private readonly ILoteProdutoRepository _loteProdutoRepository;
        private readonly ILoteInsumoRepository _loteInsumoRepository;
        private readonly IMovimentacaoProdutoRepository _movimentacaoProdutoRepository;
        private readonly IMovimentacaoInsumoRepository _movimentacaoInsumoRepository;
        private readonly ILogAlteracaoRepository _logAlteracaoRepository;

        public UnitOfWork(
            SistemaEstoqueDbContext context,
            ICategoriaRepository categoriaRepository,
            IUsuarioRepository usuarioRepository,
            IProdutoRepository produtoRepository,
            IInsumoRepository insumoRepository,
            IFornecedorRepository fornecedorRepository,
            IEstoqueProdutoRepository estoqueProdutoRepository,
            IEstoqueInsumoRepository estoqueInsumoRepository,
            ILoteProdutoRepository loteProdutoRepository,
            ILoteInsumoRepository loteInsumoRepository,
            IMovimentacaoProdutoRepository movimentacaoProdutoRepository,
            IMovimentacaoInsumoRepository movimentacaoInsumoRepository,
            ILogAlteracaoRepository logAlteracaoRepository)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
            _insumoRepository = insumoRepository;
            _fornecedorRepository = fornecedorRepository;
            _estoqueProdutoRepository = estoqueProdutoRepository;
            _estoqueInsumoRepository = estoqueInsumoRepository;
            _movimentacaoProdutoRepository = movimentacaoProdutoRepository;
            _movimentacaoInsumoRepository = movimentacaoInsumoRepository;
            _loteProdutoRepository = loteProdutoRepository;
            _loteInsumoRepository = loteInsumoRepository;
            _logAlteracaoRepository = logAlteracaoRepository;
        }

        public ICategoriaRepository Categorias => _categoriaRepository;
        public IUsuarioRepository Usuarios => _usuarioRepository;
        public IProdutoRepository Produtos => _produtoRepository;
        public IInsumoRepository Insumos => _insumoRepository;
        public IFornecedorRepository Fornecedores => _fornecedorRepository;
        public IEstoqueProdutoRepository EstoquesProdutos => _estoqueProdutoRepository;
        public IEstoqueInsumoRepository EstoquesInsumos => _estoqueInsumoRepository;
        public ILoteProdutoRepository LotesProdutos => _loteProdutoRepository;
        public ILoteInsumoRepository LoteInsumos => _loteInsumoRepository;
        public IMovimentacaoProdutoRepository MovimentacoesProdutos => _movimentacaoProdutoRepository;
        public IMovimentacaoInsumoRepository MovimentacoesInsumos => _movimentacaoInsumoRepository;
        public ILogAlteracaoRepository LogsAlteracoes => _logAlteracaoRepository;

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
