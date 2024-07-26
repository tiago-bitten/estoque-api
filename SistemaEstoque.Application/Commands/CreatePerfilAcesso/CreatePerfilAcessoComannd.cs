using MediatR;
using SistemaEstoque.Application.DTOs;

namespace SistemaEstoque.Application.Commands.CreatePerfilAcesso
{
    public class CreatePerfilAcessoComannd : IRequest<CreatePerfilAcessoResponse>
    {
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public PermissaoProdutoDTO PermissaoProduto { get; set; }
        public PermissaoInsumoDTO PermissaoInsumo { get; set; }
        public PermissaoCategoriaDTO PermissaoCategoria { get; set; }
    }
}
