namespace SistemaEstoque.Domain.Entities.Permissoes
{
    public sealed class PermissaoProduto : PermissaoBase
    {
        public int PerfilAcessoId { get; set; }
        public PerfilAcesso PerfilAcesso { get; set; }
    }
}
