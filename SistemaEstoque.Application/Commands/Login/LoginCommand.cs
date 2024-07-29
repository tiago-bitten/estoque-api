using MediatR;

namespace SistemaEstoque.Application.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public int TenantId { get; set; }
}