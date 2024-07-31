using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateUsuarioCommandHandler(
            IUnitOfWork uow,
            IMapper mapper, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<CreateUsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioRequest = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            /**if (!usuario.PerfilAcesso.PermissaoUsuario.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar usuários");**/
            
            var usuario = _mapper.Map<Usuario>(request);

            var existsUsuario = await _uow.Usuarios.GetByEmailAsync(request.Email);
            if (existsUsuario != null)
                throw new Exception("Usuário já cadastrado");

            usuario.Empresa = empresa;
            
            var senhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);
            usuario.Senha = senhaHash;

            await _uow.Usuarios.AddAsync(usuario, empresa.Id);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateUsuarioResponse>(usuario);

            return await Task.FromResult(response);
        }
    }
}
