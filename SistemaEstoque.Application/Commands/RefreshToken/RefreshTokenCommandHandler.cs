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
        var principal = _tokenService.GetPrincipalFromExpiredToken(request.Token);
        
        var usuarioId = int.Parse(principal.Claims.First(x => x.Type == "UsuarioId").Value);
        var usuario = await _uow.Usuarios.GetByIdAsync(usuarioId);
        
        var refreshToken = await _uow.RefreshTokens.GetByTokenAsync(usuario.RefreshToken.Token);
        
        if (refreshToken.ExpiraEm < DateTime.UtcNow || refreshToken.IsRevogado)
            throw new Exception("Refresh token expired");
        
        refreshToken = await _tokenService.GenerateRefreshToken(usuario);
        var accessToken = _tokenService.GenerateAccessToken(usuario);
        
    }
}