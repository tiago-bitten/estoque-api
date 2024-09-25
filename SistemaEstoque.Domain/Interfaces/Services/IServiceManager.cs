namespace SistemaEstoque.Domain.Interfaces.Services;

public interface IServiceManager
{
    IAuditoriaEntidadeService AuditoriaEntidades { get; }
    ICategoriaService Categorias { get; }
    IEstoqueService Estoques { get; }
    IFornecedorService Fornecedores { get; }
    IItemService Items { get; }
    ILoteService Lotes { get; }
    IMovimentacaoService Movimentacoes { get; }
    IProprietarioService Proprietarios { get; }
    IUsuarioService Usuarios { get; }
}