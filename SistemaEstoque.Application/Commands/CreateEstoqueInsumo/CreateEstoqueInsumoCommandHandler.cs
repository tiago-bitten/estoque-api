using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateEstoqueInsumo
{
    public class CreateEstoqueInsumoCommandHandler : IRequestHandler<CreateEstoqueInsumoCommand, CreateEstoqueInsumoResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IInsumoService _insumoService;

        public CreateEstoqueInsumoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IInsumoService insumoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _insumoService = insumoService;
        }

        public async Task<CreateEstoqueInsumoResponse> Handle(CreateEstoqueInsumoCommand request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var insumo = await _insumoService.GetAndValidateEntityAsync(request.InsumoId);

            var exitsEstoqueInsumo = await _unitOfWork.EstoquesInsumos.FindAsync(x => x.InsumoId == request.InsumoId && x.Removido == false);

            if (exitsEstoqueInsumo != null)
                throw new Exception("Já existe um estoque para o insumo informado.");

            if (request.QuantidadeMinima > request.QuantidadeMaxima)
                throw new Exception("Quantidade minima deve ser menor que a quantidade maxima.");
        
            var estoqueInsumo = _mapper.Map<EstoqueInsumo>(request);

            estoqueInsumo.Insumo = insumo;
            estoqueInsumo.EmpresaId = empresaId;

            await _unitOfWork.EstoquesInsumos.AddAsync(estoqueInsumo, empresaId);
            await _unitOfWork.CommitAsync();

            var response = _mapper.Map<CreateEstoqueInsumoResponse>(estoqueInsumo);

            return await Task.FromResult(response);
        }
    }
}
