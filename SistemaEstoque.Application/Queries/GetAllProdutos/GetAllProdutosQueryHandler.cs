using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
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

            var totalProdutos = await _uow.Items.GetAll(empresaId).CountAsync(cancellationToken);
            var produtos = await _uow.Items.GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);

            return new GetAllProdutosResponse(produtosDTO, totalProdutos);
        }
    }
}
