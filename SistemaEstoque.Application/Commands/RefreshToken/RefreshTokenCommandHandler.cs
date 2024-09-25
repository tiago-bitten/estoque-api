using System.Security.Claims;
using MediatR;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Application.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;
    private readonly IServiceManager _serviceManager;

    public RefreshTokenCommandHandler(
        IUnitOfWork uow,
        ITokenService tokenService, IServiceManager serviceManager)
    {
        _uow = uow;
        _tokenService = tokenService;
        _serviceManager = serviceManager;
    }

    public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _uow.RefreshTokens.GetByTokenAsync(request.RefreshToken);
        
        if (refreshToken is null || !refreshToken.TokenValido)
            throw new UnauthorizedAccessException("Faça login novamente");

        var usuarioId = _tokenService
            .GetPrincipalFromExpiredToken(request.AccessToken)
            .GetUsuarioId();
        
        var usuarioAccessToken = await _serviceManager.Usuarios.GetAndEnsureExistsAsync(usuarioId);
        var usuarioRefreshToken = refreshToken.Usuario;
        
        if (usuarioAccessToken.Id != usuarioRefreshToken.Id)
            throw new UnauthorizedAccessException("Faça login novamente");
        
        var newRefreshToken = await _tokenService.GenerateRefreshTokenAsync(usuarioRefreshToken);
        var newAccessToken = _tokenService.GenerateAccessToken(usuarioRefreshToken);

        await _uow.CommitAsync();

        var response = new RefreshTokenResponse(newAccessToken, newRefreshToken);

        return response;
    }
}