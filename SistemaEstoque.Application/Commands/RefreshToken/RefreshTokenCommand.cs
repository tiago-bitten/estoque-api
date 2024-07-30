using MediatR;

namespace SistemaEstoque.Application.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<RefreshTokenResponse>
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}