using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Application.Commands.CreateCategoria
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, CreateCategoriaResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAmbienteUsuario _ambienteUsuario;
        private readonly IServiceManager _serviceManager;

        public CreateCategoriaCommandHandler(
            IUnitOfWork uow,
            IMapper mapper, IAmbienteUsuario ambienteUsuario, IServiceManager serviceManager)
        {
            _uow = uow;
            _mapper = mapper;
            _ambienteUsuario = ambienteUsuario;
            _serviceManager = serviceManager;
        }

        public async Task<CreateCategoriaResponse> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var ambiente = await _ambienteUsuario.GetUsuarioAndTenantAsync("PerfilAcesso.PermissaoCategoria");

            if (!ambiente.usuario.PerfilAcesso.PermissaoCategoria.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar categorias");

            var categoria = _mapper.Map<Categoria>(request);

            await _serviceManager.Categorias.EnsureNotExistsByNameAsync(categoria.Nome);

            await _uow.Categorias.AddAsync(categoria);
            await _uow.CommitAndAuditAsync(categoria, "categorias", _serviceManager);
            
            var response = _mapper.Map<CreateCategoriaResponse>(categoria);

            return response;
        }
    }
}
