using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateLote
{
    public class CreateLoteCommandHandler : IRequestHandler<CreateLoteCommand, CreateLoteResponse>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IFornecedorService _fornecedorService;
        private readonly IProdutoService _produtoService;
        private readonly IInsumoService _insumoService;

        public CreateLoteCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IFornecedorService fornecedorService,
            IProdutoService produtoService,
            IInsumoService insumoService)
        {
            _uow = uow;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
            _produtoService = produtoService;
            _insumoService = insumoService;
        }

        public async Task<CreateLoteResponse> Handle(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var fornecedor = await _fornecedorService.GetAndValidateEntityAsync(request.FornecedorId);

            var usuarioId = 1;

            var lote = _mapper.Map<Lote>(request);
            lote.Fornecedor = fornecedor;
            lote.EmpresaId = empresaId;

            await _uow.Lotes.AddAsync(lote, empresaId);

            request.LotesItens.ToList().ForEach(async item =>
            {
                if (item.TipoItem == ETipoItem.Produto)
                {
                    var produto = await _produtoService.GetAndValidateEntityAsync(item.ItemId);

                    var loteProduto = _mapper.Map<LoteProduto>(item);
                    loteProduto.Produto = produto;
                    loteProduto.EmpresaId = empresaId;

                    loteProduto.Lote = lote;

                    await _uow.LotesProdutos.AddAsync(loteProduto, empresaId);
                }
                else
                {
                    var insumo = await _insumoService.GetAndValidateEntityAsync(item.ItemId);

                    var loteInsumo = _mapper.Map<LoteInsumo>(item);
                    loteInsumo.Insumo = insumo;
                    loteInsumo.EmpresaId = empresaId;

                    loteInsumo.Lote = lote;

                    await _uow.LotesInsumos.AddAsync(loteInsumo, empresaId);
                }
            });

            await _uow.CommitAsync();
        }
    }
}
