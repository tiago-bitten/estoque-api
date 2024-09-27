using Microsoft.EntityFrameworkCore.Storage;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction? _transaction;
        private readonly SistemaEstoqueDbContext _context;

        public UnitOfWork(SistemaEstoqueDbContext context,
                          IEmpresaRepository empresaRepository,
                          ICategoriaRepository categoriaRepository,
                          IUsuarioRepository usuarioRepository,
                          IItemRepository itemRepository,
                          IFornecedorRepository fornecedorRepository,
                          IEstoqueRepository estoqueRepository,
                          IRemesaLoteRepository remesaLoteRepository,
                          ILoteRepository loteRepository,
                          IMovimentacaoRepository movimentacaoRepository,
                          IAuditoriaEntidadeRepository auditoriaEntidadeRepository,
                          IPerfilAcessoRepository perfilAcessoRepository,
                          IPermissaoProdutoRepository permissaoProdutoRepository,
                          IPermissaoCategoriaRepository permissaoCategoriaRepository,
                          IConfiguracaoEstoqueRepository configuracaoEstoqueRepository,
                          IRefreshTokenRepository refreshTokenRepository,
                          IAuditoriaUsuarioAcessoRepository auditoriaUsuarioAcessoRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Empresas = empresaRepository ?? throw new ArgumentNullException(nameof(empresaRepository));
            Categorias = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
            Usuarios = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            Items = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            Fornecedores = fornecedorRepository ?? throw new ArgumentNullException(nameof(fornecedorRepository));
            Estoques = estoqueRepository ?? throw new ArgumentNullException(nameof(estoqueRepository));
            RemesaLotes = remesaLoteRepository ?? throw new ArgumentNullException(nameof(remesaLoteRepository));
            Lotes = loteRepository ?? throw new ArgumentNullException(nameof(loteRepository));
            Movimentacoes = movimentacaoRepository ?? throw new ArgumentNullException(nameof(movimentacaoRepository));
            AuditoriaEntidades = auditoriaEntidadeRepository ?? throw new ArgumentNullException(nameof(auditoriaEntidadeRepository));
            PerfisAcessos = perfilAcessoRepository ?? throw new ArgumentNullException(nameof(perfilAcessoRepository));
            PermissoesProdutos = permissaoProdutoRepository ?? throw new ArgumentNullException(nameof(permissaoProdutoRepository));
            PermissoesCategorias = permissaoCategoriaRepository ?? throw new ArgumentNullException(nameof(permissaoCategoriaRepository));
            ConfiguracoesEstoques = configuracaoEstoqueRepository ?? throw new ArgumentNullException(nameof(configuracaoEstoqueRepository));
            RefreshTokens = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
            AuditoriaUsuarioAcessos = auditoriaUsuarioAcessoRepository ?? throw new ArgumentNullException(nameof(auditoriaUsuarioAcessoRepository));
        }

        public IEmpresaRepository Empresas { get; }
        public ICategoriaRepository Categorias { get; }
        public IUsuarioRepository Usuarios { get; }
        public IItemRepository Items { get; }
        public IFornecedorRepository Fornecedores { get; }
        public IEstoqueRepository Estoques { get; }
        public IRemesaLoteRepository RemesaLotes { get; }
        public ILoteRepository Lotes { get; }
        public IMovimentacaoRepository Movimentacoes { get; }
        public IAuditoriaEntidadeRepository AuditoriaEntidades { get; }
        public IPerfilAcessoRepository PerfisAcessos { get; }
        public IPermissaoProdutoRepository PermissoesProdutos { get; }
        public IPermissaoCategoriaRepository PermissoesCategorias { get; }
        public IConfiguracaoEstoqueRepository ConfiguracoesEstoques { get; }
        public IRefreshTokenRepository RefreshTokens { get; }
        public IAuditoriaUsuarioAcessoRepository AuditoriaUsuarioAcessos { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction ??= await _context.Database.BeginTransactionAsync();
        }

        public async Task<bool> CommitAsync()
        {
            if (_transaction != null)
            {
                try
                {
                    var result = await _context.SaveChangesAsync() > 0;
                    await _transaction.CommitAsync();
                    return result;
                }
                finally
                {
                    await DisposeTransactionAsync();
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await DisposeTransactionAsync();
            }
        }

        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _transaction?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
        }
    }
}
