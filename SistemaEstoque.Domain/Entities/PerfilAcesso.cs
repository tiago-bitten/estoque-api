using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Entities.Permissoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class PerfilAcesso : IdentificadorTenant
    {
        public string Nome { get; set; }

        public PermissaoProduto PermissaoProduto { get; set; }
        public PermissaoCategoria PermissaoCategoria { get; set; }
        public PermissaoInsumo PermissaoInsumo { get; set; }
        public List<Usuario> Usuarios { get; set; } = new();
    }
}
