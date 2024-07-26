using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Permissoes;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Commands.CreatePerfilAcesso
{
    public class CreatePerfilAcessoCommandHandler : IRequestHandler<CreatePerfilAcessoComannd, CreatePerfilAcessoResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreatePerfilAcessoCommandHandler(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CreatePerfilAcessoResponse> Handle(CreatePerfilAcessoComannd request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var perfilAcesso = _mapper.Map<PerfilAcesso>(request);
            var permissaoProduto = _mapper.Map<PermissaoProduto>(request);
            var permissaoInsumo = _mapper.Map<PermissaoInsumo>(request);
            var permissaoCategoria = _mapper.Map<PermissaoCategoria>(request);

            permissaoProduto.PerfilAcesso = perfilAcesso;
            permissaoInsumo.PerfilAcesso = perfilAcesso;
            permissaoCategoria.PerfilAcesso = perfilAcesso;
        
            await _uow.PerfisAcessos.AddAsync(perfilAcesso, empresaId);
            await _uow.PermissoesProdutos.AddAsync(permissaoProduto, empresaId);
            //await _uow.PermissoesInsumos.AddAsync(permissaoInsumo, empresaId);
            await _uow.PermissoesCategorias.AddAsync(permissaoCategoria, empresaId);

            await _uow.CommitAsync();

            var response = _mapper.Map<CreatePerfilAcessoResponse>(perfilAcesso);

            return response;
        }
    }
}
