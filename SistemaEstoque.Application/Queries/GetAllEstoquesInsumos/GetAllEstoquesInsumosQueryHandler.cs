using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllEstoquesInsumos
{
    public class GetAllEstoquesInsumosQueryHandler : IRequestHandler<GetAllEstoquesInsumosQuery, GetAllEstoquesInsumosResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEstoquesInsumosQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllEstoquesInsumosResponse> Handle(GetAllEstoquesInsumosQuery request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var totalEstoquesInsumos = await _unitOfWork.EstoquesInsumos.GetAll(empresaId)
                .CountAsync(cancellationToken);

            var estoquesInsumos = await _unitOfWork.EstoquesInsumos.GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            var estoquesInsumosDTO = _mapper.Map<List<EstoqueInsumoDTO>>(estoquesInsumos);

            return new GetAllEstoquesInsumosResponse(estoquesInsumosDTO, totalEstoquesInsumos);
        }
    }
}
