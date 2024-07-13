using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllEstoquesProdutos
{
    public class GetAllEstoquesProdutosQueryHandler : IRequestHandler<GetAllEstoquesProdutosQuery, GetAllEstoquesProdutosResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllEstoquesProdutosQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetAllEstoquesProdutosResponse> Handle(GetAllEstoquesProdutosQuery request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var totalEstoquesProdutos = await _uow.EstoquesProdutos.GetAll(empresaId)
                .CountAsync(cancellationToken);

            var estoquesProdutos = await _uow.EstoquesProdutos.GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            var estoquesProdutosDTO = _mapper.Map<List<EstoqueProdutoDTO>>(estoquesProdutos);

            return new GetAllEstoquesProdutosResponse(estoquesProdutosDTO, totalEstoquesProdutos);
        }
    }
}
