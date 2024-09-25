using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(
        IUnitOfWork uow,
        ITokenService tokenService)
    {
        _uow = uow;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _uow.Usuarios.GetByEmailAsync(request.Email, "Empresa");
        
        if (usuario is null)
            throw new Exception("E-mail ou senha inválidos");
        
        var senhaInvalida = !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha);
        
        if (senhaInvalida)
            throw new Exception("E-mail ou senha inválidos");

        usuario.VerifyAcessoBloqueado();
        usuario.Empresa.VerifyAcessoBloqueado();

        var accessToken = _tokenService.GenerateAccessToken(usuario);
        var refreshToken = await _tokenService.GenerateRefreshTokenAsync(usuario);

        var response = new LoginResponse(accessToken, refreshToken.Token);

        return response;
    }
}