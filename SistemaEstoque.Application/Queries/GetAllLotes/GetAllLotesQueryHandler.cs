using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllLotes
{
    public class GetAllLotesQueryHandler : IRequestHandler<GetAllLotesQuery, GetAllLotesResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllLotesQueryHandler(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetAllLotesResponse> Handle(GetAllLotesQuery request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var totalLotes = await _uow.Lotes.GetAll(empresaId)
                .CountAsync();

            var lotes = await _uow.Lotes.GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            var lotesDTO = _mapper.Map<List<LoteDTO>>(lotes);

            return new GetAllLotesResponse(lotesDTO, totalLotes);
        }
    }
}
