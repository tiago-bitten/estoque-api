using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllFornecedores
{
    public class GetAllFornecedoresQueryHandler : IRequestHandler<GetAllFornecedoresQuery, GetAllFornecedoresResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllFornecedoresQueryHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllFornecedoresResponse> Handle(GetAllFornecedoresQuery request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var totalFornecedores = await _unitOfWork.Fornecedores.GetAll(empresaId)
                .CountAsync(cancellationToken);

            var fornecedores = await _unitOfWork.Fornecedores.GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            var fornecedoresDTO = _mapper.Map<List<FornecedorDTO>>(fornecedores);

            return new GetAllFornecedoresResponse(fornecedoresDTO, totalFornecedores);
        }
    }
}
