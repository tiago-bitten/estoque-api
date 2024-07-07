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

        public CreateUsuarioCommandHandler(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CreateUsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(request);

            var existsUsuario = await _uow.Usuarios.GetByEmailAsync(request.Email);
            if (existsUsuario != null)
                throw new Exception("Usuário já cadastrado");
        
            await _uow.Usuarios.AddAsync(usuario, 1);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateUsuarioResponse>(usuario);

            return await Task.FromResult(response);
        }
    }
}
