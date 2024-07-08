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
        private readonly ILoteRepository _loteRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public UnitOfWork(
            SistemaEstoqueDbContext context,
            ICategoriaRepository categoriaRepository,
            IUsuarioRepository usuarioRepository,
            IProdutoRepository produtoRepository,
            IFornecedorRepository fornecedorRepository,
            IEstoqueRepository estoqueRepository,
            ILoteRepository loteRepository,
            IMovimentacaoRepository movimentacaoRepository)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _estoqueRepository = estoqueRepository;
            _loteRepository = loteRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public ICategoriaRepository Categorias => _categoriaRepository;
        public IUsuarioRepository Usuarios => _usuarioRepository;
        public IProdutoRepository Produtos => _produtoRepository;
        public IFornecedorRepository Fornecedores => _fornecedorRepository;
        public IEstoqueRepository Estoques => _estoqueRepository;
        public ILoteRepository Lotes => _loteRepository;
        public IMovimentacaoRepository Movimentacoes => _movimentacaoRepository;

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
