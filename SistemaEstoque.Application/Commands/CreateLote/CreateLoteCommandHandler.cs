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
        private readonly IEstoqueService<EstoqueProduto> _estoqueProdutoService;
        private readonly IEstoqueService<EstoqueInsumo> _estoqueInsumoService;

        public CreateLoteCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IFornecedorService fornecedorService,
            IProdutoService produtoService,
            IInsumoService insumoService,
            IEstoqueService<EstoqueProduto> estoqueProdutoService,
            IEstoqueService<EstoqueInsumo> estoqueInsumoService)
        {
            _uow = uow;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
            _produtoService = produtoService;
            _insumoService = insumoService;
            _estoqueProdutoService = estoqueProdutoService;
            _estoqueInsumoService = estoqueInsumoService;
        }

        public async Task<CreateLoteResponse> Handle(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var fornecedor = await _fornecedorService.GetAndValidateEntityAsync(request.FornecedorId);

            var usuarioId = 1;
            var usuarioRecebimentoId = request.UsuarioRecebimentoId;

            var lote = _mapper.Map<Lote>(request);
            lote.Fornecedor = fornecedor;
            lote.EmpresaId = empresaId;
            lote.UsuarioRecebimentoId = usuarioRecebimentoId;

            await _uow.Lotes.AddAsync(lote, empresaId);

            foreach (var item in request.LotesItens)
            {
                if (item.TipoItem == ETipoItem.Produto)
                {
                    var produto = await _produtoService.GetAndValidateEntityAsync(item.ItemId);

                    var loteProduto = _mapper.Map<LoteProduto>(item);
                    loteProduto.Produto = produto;
                    loteProduto.EmpresaId = empresaId;
                    loteProduto.Lote = lote;

                    await _uow.LotesProdutos.AddAsync(loteProduto, empresaId);
                    await _estoqueProdutoService.UpdateEstoque(produto.EstoqueProduto, item.Quantidade, ETipoMovimentacao.Entrada);
                    
                    var movimentacaoProduto = _mapper.Map<MovimentacaoProduto>(item);

                    movimentacaoProduto.Produto = produto;
                    movimentacaoProduto.EstoqueProduto = produto.EstoqueProduto;
                    movimentacaoProduto.LoteProduto = loteProduto;
                    movimentacaoProduto.UsuarioId = usuarioId;

                    await _uow.MovimentacoesProdutos.AddAsync(movimentacaoProduto, empresaId);
                }
                else
                {
                    var insumo = await _insumoService.GetAndValidateEntityAsync(item.ItemId);

                    var loteInsumo = _mapper.Map<LoteInsumo>(item);
                    loteInsumo.Insumo = insumo;
                    loteInsumo.EmpresaId = empresaId;
                    loteInsumo.Lote = lote;

                    await _uow.LotesInsumos.AddAsync(loteInsumo, empresaId);
                    await _estoqueInsumoService.UpdateEstoque(insumo.EstoqueInsumo, item.Quantidade, ETipoMovimentacao.Entrada);
                    
                    var movimentacaoInsumo = _mapper.Map<MovimentacaoInsumo>(item);

                    movimentacaoInsumo.Insumo = insumo;
                    movimentacaoInsumo.EstoqueInsumo = insumo.EstoqueInsumo;
                    movimentacaoInsumo.LoteInsumo = loteInsumo;
                    movimentacaoInsumo.UsuarioId = usuarioId;

                    await _uow.MovimentacoesInsumos.AddAsync(movimentacaoInsumo, empresaId);
                }
            }

            await _uow.CommitAsync();

            var response = _mapper.Map<CreateLoteResponse>(lote);

            return await Task.FromResult(response);
        }

    }
}
