using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;
using SistemaEstoque.Domain.Interfaces.Repositories;
using System.Dynamic;

namespace SistemaEstoque.Application.Queries.GetAllInsumos
{
    public class GetAllInsumosQueryHandler : IRequestHandler<GetAllInsumosQuery, GetAllInsumosResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllInsumosQueryHandler(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetAllInsumosResponse> Handle(GetAllInsumosQuery request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var totalInsumos = await _uow.Insumos.GetAll(empresaId)
                .CountAsync(cancellationToken);

            var insumos = await _uow.Insumos.GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            var insumosDTO = _mapper.Map<List<InsumoDTO>>(insumos);

            return new GetAllInsumosResponse(insumosDTO, totalInsumos);
        }
    }
}
