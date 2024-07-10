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
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly ILoteProdutoRepository _loteProdutoRepository;
        private readonly IMovimentacaoProdutoRepository _movimentacaoProdutoRepository;
        private readonly ILogAlteracaoRepository _logAlteracaoRepository;

        public UnitOfWork(
            SistemaEstoqueDbContext context,
            ICategoriaRepository categoriaRepository,
            IUsuarioRepository usuarioRepository,
            IProdutoRepository produtoRepository,
            IFornecedorRepository fornecedorRepository,
            IEstoqueRepository estoqueRepository,
            ILoteProdutoRepository loteProdutoRepository,
            IMovimentacaoProdutoRepository movimentacaoProdutoRepository,
            ILogAlteracaoRepository logAlteracaoRepository)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _estoqueRepository = estoqueRepository;
            _movimentacaoProdutoRepository = movimentacaoProdutoRepository;
            _loteProdutoRepository = loteProdutoRepository;
            _logAlteracaoRepository = logAlteracaoRepository;
        }

        public ICategoriaRepository Categorias => _categoriaRepository;
        public IUsuarioRepository Usuarios => _usuarioRepository;
        public IProdutoRepository Produtos => _produtoRepository;
        public IFornecedorRepository Fornecedores => _fornecedorRepository;
        public IEstoqueRepository Estoques => _estoqueRepository;
        public ILoteProdutoRepository LotesProdutos => _loteProdutoRepository;
        public IMovimentacaoProdutoRepository MovimentacoesProdutos => _movimentacaoProdutoRepository;
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
