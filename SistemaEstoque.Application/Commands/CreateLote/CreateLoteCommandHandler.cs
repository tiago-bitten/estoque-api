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
        private readonly IItemService _itemService;
        private readonly IInsumoService _insumoService;
        private readonly IEstoqueService<EstoqueProduto> _estoqueProdutoService;
        private readonly IEstoqueService<EstoqueInsumo> _estoqueInsumoService;
        private readonly ICurrentUserService _currentUserService;

        public CreateLoteCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IFornecedorService fornecedorService,
            IItemService itemService,
            IInsumoService insumoService,
            IEstoqueService<EstoqueProduto> estoqueProdutoService,
            IEstoqueService<EstoqueInsumo> estoqueInsumoService, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
            _itemService = itemService;
            _insumoService = insumoService;
            _estoqueProdutoService = estoqueProdutoService;
            _estoqueInsumoService = estoqueInsumoService;
            _currentUserService = currentUserService;
        }

        public async Task<CreateLoteResponse> Handle(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            /**if (!usuario.PerfilAcesso.PermissaoLote.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar lotes");**/
            
            var fornecedor = await _fornecedorService.GetAndValidateEntityAsync(request.FornecedorId);

            var lote = _mapper.Map<Lote>(request);
            lote.Fornecedor = fornecedor;
            lote.Empresa = empresa;
            lote.UsuarioRecebimentoId = request.UsuarioRecebimentoId;

            await _uow.Lotes.AddAsync(lote, empresa.Id);

            foreach (var item in request.LotesItens)
            {
                if (item.TipoItem == ETipoItem.Produto)
                {
                    var produto = await _itemService.GetAndValidateEntityAsync(item.ItemId);

                    var loteProduto = _mapper.Map<LoteProduto>(item);
                    loteProduto.Produto = produto;
                    loteProduto.Empresa = empresa;
                    loteProduto.Lote = lote;

                    await _uow.LotesItems.AddAsync(loteProduto, empresa.Id);
                    await _estoqueProdutoService.UpdateEstoque(produto.EstoqueProduto, item.Quantidade, ETipoMovimentacao.Entrada);
                    
                    var movimentacaoProduto = _mapper.Map<MovimentacaoProduto>(item);

                    movimentacaoProduto.Produto = produto;
                    movimentacaoProduto.EstoqueProduto = produto.EstoqueProduto;
                    movimentacaoProduto.LoteProduto = loteProduto;
                    movimentacaoProduto.Usuario = usuario;

                    await _uow.Movimentacoes.AddAsync(movimentacaoProduto, empresa.Id);
                }
                else
                {
                    var insumo = await _insumoService.GetAndValidateEntityAsync(item.ItemId);

                    var loteInsumo = _mapper.Map<LoteInsumo>(item);
                    loteInsumo.Insumo = insumo;
                    loteInsumo.Empresa = empresa;
                    loteInsumo.Lote = lote;

                    await _uow.LotesInsumos.AddAsync(loteInsumo, empresa.Id);
                    await _estoqueInsumoService.UpdateEstoque(insumo.EstoqueInsumo, item.Quantidade, ETipoMovimentacao.Entrada);
                    
                    var movimentacaoInsumo = _mapper.Map<MovimentacaoInsumo>(item);

                    movimentacaoInsumo.Insumo = insumo;
                    movimentacaoInsumo.EstoqueInsumo = insumo.EstoqueInsumo;
                    movimentacaoInsumo.LoteInsumo = loteInsumo;
                    movimentacaoInsumo.Usuario = usuario;

                    await _uow.MovimentacoesInsumos.AddAsync(movimentacaoInsumo, empresa.Id);
                }
            }

            await _uow.CommitAsync();

            var response = _mapper.Map<CreateLoteResponse>(lote);

            return await Task.FromResult(response);
        }

    }
}
