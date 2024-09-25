using AutoMapper;
using MediatR;
using SistemaEstoque.Application.Commands.CreateProduto;
using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Application.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAmbienteUsuario _ambienteUsuario;
        private readonly IServiceManager _serviceManager;

        public CreateItemCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IAmbienteUsuario ambienteUsuario,
            IServiceManager serviceManager)
        {
            _uow = uow;
            _mapper = mapper;
            _ambienteUsuario = ambienteUsuario;
            _serviceManager = serviceManager;
        }

        public async Task<CreateItemResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var ambiente = await _ambienteUsuario.GetUsuarioAndTenantAsync("PerfilAcesso.PermissaoProduto");
            
            if (!ambiente.Usuario.PerfilAcesso.PermissaoProduto.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar produtos");

            var categoria = await _serviceManager.Categorias.GetAndEnsureExistsAsync(request.CategoriaId);

            var item = _mapper.Map<Item>(request);

            item.Categoria = categoria;

            await _uow.Items.AddAsync(item);
            await _uow.CommitAndAuditAsync(item,"items", _serviceManager);

            var response = _mapper.Map<CreateItemResponse>(item);

            return response;
        }
    }
}
