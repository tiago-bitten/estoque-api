using SistemaEstoque.Domain.Entities.Permissoes;

namespace SistemaEstoque.Domain.Entities
{
    public class PerfilAcesso : EntidadeBase
    {
        public string Nome { get; set; }

        public PermissaoProduto PermissaoProduto { get; set; }
        public PermissaoCategoria PermissaoCategoria { get; set; }
        public PermissaoInsumo PermissaoInsumo { get; set; }
        public IEnumerable<Usuario?> Usuarios { get; set; }
    }
}
