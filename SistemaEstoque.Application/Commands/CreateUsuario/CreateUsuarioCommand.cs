using MediatR;

namespace SistemaEstoque.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<CreateUsuarioResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
