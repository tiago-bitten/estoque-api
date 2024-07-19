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

            permissaoProduto.PerfilAcesso = perfilAcesso;
        

        }
    }
}
