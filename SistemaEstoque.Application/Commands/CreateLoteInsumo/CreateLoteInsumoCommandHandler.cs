using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateLoteInsumo
{
    public class CreateLoteInsumoCommandHandler : IRequestHandler<CreateLoteInsumoCommand, CreateLoteInsumoResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IInsumoService _insumoService;
        private readonly IFornecedorService _fornecedorService;
        private readonly IEstoqueService<EstoqueInsumo> _estoqueService;

        public CreateLoteInsumoCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IInsumoService insumoService,
            IFornecedorService fornecedorService,
            IEstoqueService<EstoqueInsumo> estoqueService)
        {
            _uow = uow;
            _mapper = mapper;
            _insumoService = insumoService;
            _fornecedorService = fornecedorService;
            _estoqueService = estoqueService;
        }

        public async Task<CreateLoteInsumoResponse> Handle(CreateLoteInsumoCommand request, CancellationToken cancellationToken)
        {
            var insumo = await _insumoService.GetAndValidateEntityAsync(request.InsumoId);
            var estoque = insumo.EstoqueInsumo;

            if (estoque == null)
                throw new Exception("Primeiro crie o estoque");

            var fornecedor = await _fornecedorService.GetAndValidateEntityAsync(request.FornecedorId);

            var lote = _mapper.Map<LoteInsumo>(request);
            var movimentacao = _mapper.Map<MovimentoInsumo>(request);

            lote.Insumo = insumo;
            lote.Fornecedor = fornecedor;
            lote.EmpresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            movimentacao.LoteInsumo = lote;
            movimentacao.Insumo = insumo;
            movimentacao.UsuarioId = 1;
            movimentacao.EmpresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            await _uow.LoteInsumos.AddAsync(lote, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.MovimentacoesInsumos.AddAsync(movimentacao, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _estoqueService.UpdateEstoque(estoque, request.Quantidade, ETipoMovimentacao.Entrada);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateLoteInsumoResponse>(lote);

            return await Task.FromResult(response);
        }
    }
}
