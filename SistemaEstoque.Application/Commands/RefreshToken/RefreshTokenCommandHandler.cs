using MediatR;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;

    public RefreshTokenCommandHandler(
        IUnitOfWork uow,
        ITokenService tokenService)
    {
        _uow = uow;
        _tokenService = tokenService;
    }

    public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var validateExpiredAccessToken = _tokenService.ValidateExpiredAccessToken(request.AccessToken);

        if (!validateExpiredAccessToken)
            throw new Exception("Access Token continua sendo válido");
        
        var refreshToken = await _uow.RefreshTokens.GetByTokenAsync(request.RefreshToken);
        
        if (refreshToken is null || refreshToken.ExpiraEm < DateTime.UtcNow || refreshToken.IsRevogado)
            throw new Exception("Faça login novamente");

        var usuario = refreshToken.Usuario;
        
        var newRefreshToken = await _tokenService.GenerateRefreshToken(usuario);
        var newAccessToken = _tokenService.GenerateAccessToken(usuario);

        return new RefreshTokenResponse()
        {
            RefreshToken = newRefreshToken.Token,
            Token = newAccessToken,
            Expiration = newRefreshToken.ExpiraEm
        };
    }
}