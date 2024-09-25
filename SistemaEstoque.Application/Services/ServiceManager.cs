using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        #region Fields
        public IAuditoriaEntidadeService AuditoriaEntidades { get; }
        public ICategoriaService Categorias { get; }
        public IEstoqueService Estoques { get; }
        public IFornecedorService Fornecedores { get; }
        public IItemService Items { get; }
        public ILoteService Lotes { get; }
        public IMovimentacaoService Movimentacoes { get; }
        public IProprietarioService Proprietarios { get; }
        public ITokenService Tokens { get; }
        public IUsuarioService Usuarios { get; }
        #endregion
        
        #region Constructor
        public ServiceManager(
            IAuditoriaEntidadeService auditoriaEntidadeService,
            ICategoriaService categoriaService,
            IEstoqueService estoqueService,
            IFornecedorService fornecedorService,
            IItemService itemService,
            ILoteService loteService,
            IMovimentacaoService movimentacaoService,
            IProprietarioService proprietarioService,
            ITokenService tokenService,
            IUsuarioService usuarioService)
        {
            AuditoriaEntidades = auditoriaEntidadeService ?? throw new ArgumentNullException(nameof(auditoriaEntidadeService));
            Categorias = categoriaService ?? throw new ArgumentNullException(nameof(categoriaService));
            Estoques = estoqueService ?? throw new ArgumentNullException(nameof(estoqueService));
            Fornecedores = fornecedorService ?? throw new ArgumentNullException(nameof(fornecedorService));
            Items = itemService ?? throw new ArgumentNullException(nameof(itemService));
            Lotes = loteService ?? throw new ArgumentNullException(nameof(loteService));
            Movimentacoes = movimentacaoService ?? throw new ArgumentNullException(nameof(movimentacaoService));
            Proprietarios = proprietarioService ?? throw new ArgumentNullException(nameof(proprietarioService));
            Tokens = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            Usuarios = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }
        #endregion
    }
}
