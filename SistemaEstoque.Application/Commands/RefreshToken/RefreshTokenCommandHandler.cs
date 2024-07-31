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

        var usuarioAccessToken = await _tokenService.GetUsuarioByAccessTokenAsync(request.AccessToken);
        var usuarioRefreshToken = refreshToken.Usuario;
        
        if (usuarioAccessToken.Id != usuarioRefreshToken.Id)
            throw new Exception("Faça login novamente");
        
        var newRefreshToken = await _tokenService.GenerateRefreshToken(usuarioRefreshToken);
        var newAccessToken = _tokenService.GenerateAccessToken(usuarioRefreshToken);

        return new RefreshTokenResponse()
        {
            RefreshToken = newRefreshToken.Token,
            Token = newAccessToken,
            Expiration = newRefreshToken.ExpiraEm
        };
    }
}