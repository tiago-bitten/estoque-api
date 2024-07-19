using SistemaEstoque.Application.DTOs;

namespace SistemaEstoque.Application.Commands.CreatePerfilAcesso
{
    public class CreatePerfilAcessoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public bool Visualizar { get; set; }
        public PermissaoProdutoDTO PermissaoProduto { get; set; }
    }
}
