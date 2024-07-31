using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreatePerfilAcesso
{
    public class CreatePerfilAcessoCommandHandler : IRequestHandler<CreatePerfilAcessoComannd, CreatePerfilAcessoResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreatePerfilAcessoCommandHandler(
            IUnitOfWork uow,
            IMapper mapper, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<CreatePerfilAcessoResponse> Handle(CreatePerfilAcessoComannd request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            /**if (!usuario.PerfilAcesso.PermissaoPerfilAcesso.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar perfis de acesso");**/

            var perfilAcesso = _mapper.Map<PerfilAcesso>(request);
            var permissaoProduto = _mapper.Map<PermissaoProduto>(request);
            var permissaoInsumo = _mapper.Map<PermissaoInsumo>(request);
            var permissaoCategoria = _mapper.Map<PermissaoCategoria>(request);

            permissaoProduto.PerfilAcesso = perfilAcesso;
            permissaoInsumo.PerfilAcesso = perfilAcesso;
            permissaoCategoria.PerfilAcesso = perfilAcesso;
        
            await _uow.PerfisAcessos.AddAsync(perfilAcesso, empresa.Id);
            await _uow.PermissoesProdutos.AddAsync(permissaoProduto, empresa.Id);
            //await _uow.PermissoesInsumos.AddAsync(permissaoInsumo, empresa.Id);
            await _uow.PermissoesCategorias.AddAsync(permissaoCategoria, empresa.Id);

            await _uow.CommitAsync();

            var response = _mapper.Map<CreatePerfilAcessoResponse>(perfilAcesso);

            return response;
        }
    }
}
