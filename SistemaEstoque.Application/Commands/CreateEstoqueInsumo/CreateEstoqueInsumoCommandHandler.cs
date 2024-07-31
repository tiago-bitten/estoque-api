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
        private readonly ICurrentUserService _currentUserService;

        public CreateEstoqueInsumoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IInsumoService insumoService, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _insumoService = insumoService;
            _currentUserService = currentUserService;
        }

        public async Task<CreateEstoqueInsumoResponse> Handle(CreateEstoqueInsumoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            /**if (!usuario.PerfilAcesso.PermissaoEstoqueInsumo.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar estoque de insumo");**/
            
            var insumo = await _insumoService.GetAndValidateEntityAsync(request.InsumoId);

            var exitsEstoqueInsumo = await _unitOfWork.EstoquesInsumos.FindAsync(x => x.InsumoId == request.InsumoId && x.Removido == false);

            if (exitsEstoqueInsumo != null)
                throw new Exception("Já existe um estoque para o insumo informado.");

            if (request.QuantidadeMinima > request.QuantidadeMaxima)
                throw new Exception("Quantidade minima deve ser menor que a quantidade maxima.");
        
            var estoqueInsumo = _mapper.Map<EstoqueInsumo>(request);

            estoqueInsumo.Insumo = insumo;
            estoqueInsumo.Empresa = empresa;

            await _unitOfWork.EstoquesInsumos.AddAsync(estoqueInsumo, empresa.Id);
            await _unitOfWork.CommitAsync();

            var response = _mapper.Map<CreateEstoqueInsumoResponse>(estoqueInsumo);

            return await Task.FromResult(response);
        }
    }
}
