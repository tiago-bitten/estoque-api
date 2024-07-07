using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Infra.Repositories;

namespace SistemaEstoque.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaEstoqueDbContext _context;
        private ICategoriaRepository _categoriaRepository;
        private IUsuarioRepository _usuarioRepository;
        private IProdutoRepository _produtoRepository;
        private IFornecedorRepository _fornecedorRepository;

        public UnitOfWork(SistemaEstoqueDbContext context)
        {
            _context = context;
        }

        public ICategoriaRepository Categorias => _categoriaRepository ??= new CategoriaRepository(_context);

        public IUsuarioRepository Usuarios => _usuarioRepository ??= new UsuarioRepository(_context);

        public IProdutoRepository Produtos => _produtoRepository ??= new ProdutoRepository(_context);
        public IFornecedorRepository Fornecedores => _fornecedorRepository ??= new FornecedorRepository(_context);

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
