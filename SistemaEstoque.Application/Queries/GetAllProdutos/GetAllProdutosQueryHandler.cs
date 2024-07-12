using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllProdutos
{
    public class GetAllProdutosQueryHandler : IRequestHandler<GetAllProdutosQuery, GetAllProdutosResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllProdutosQueryHandler(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetAllProdutosResponse> Handle(GetAllProdutosQuery request, CancellationToken cancellationToken)
        {
            // ALTERAR_EMPRESA
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var produtos = _uow.Produtos.GetAll(empresaId).AsEnumerable();

            var response = _mapper.Map<GetAllProdutosResponse>(produtos);

            return await Task.FromResult(response);
        }
    }
}
