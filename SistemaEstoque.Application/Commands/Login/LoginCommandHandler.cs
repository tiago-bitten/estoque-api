using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IServiceBase<Empresa> _empresaService;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(
        IMapper mapper,
        IUnitOfWork uow,
        IServiceBase<Empresa> empresaService,
        ITokenService tokenService)
    {
        _mapper = mapper;
        _uow = uow;
        _empresaService = empresaService;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _uow.Usuarios.FindAsync(x => x.Email == request.Email && x.EmpresaId == request.TenantId);
        
        if (usuario == null)
            throw new Exception("E-mail ou senha inválidos");
        
        var senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha);
        
        if (!senhaValida)
            throw new Exception("E-mail ou senha inválidos");
        
        var accessToken = _tokenService.GenerateAccessToken(usuario);
        var refreshToken = await _tokenService.GenerateRefreshToken(usuario);

        var response = new LoginResponse()
        {
            Token = accessToken,
            RefreshToken = refreshToken.Token,
            Expiration = refreshToken.ExpiraEm
        };

        return response;
    }
}