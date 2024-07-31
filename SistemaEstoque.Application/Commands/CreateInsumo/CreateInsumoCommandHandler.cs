using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateInsumo
{
    public class CreateInsumoCommandHandler : IRequestHandler<CreateInsumoCommand, CreateInsumoResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;
        private readonly ICurrentUserService _currentUserService;

        public CreateInsumoCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            ICategoriaService categoriaService, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _categoriaService = categoriaService;
            _currentUserService = currentUserService;
        }

        public async Task<CreateInsumoResponse> Handle(CreateInsumoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            if (!usuario.PerfilAcesso.PermissaoInsumo.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar insumos");
            
            var insumo = _mapper.Map<Insumo>(request);

            if (request.CategoriaId.HasValue)
            {
                var categoria = await _categoriaService.GetAndValidateEntityAsync(request.CategoriaId.Value);
                insumo.Categoria = categoria;
            }

            await _uow.Insumos.AddAsync(insumo, empresa.Id);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateInsumoResponse>(insumo);   

            return await Task.FromResult(response);
        }
    }
}
