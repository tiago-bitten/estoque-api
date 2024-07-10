using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateLote
{
    public class CreateLoteProdutoCommandHandler : IRequestHandler<CreateLoteProdutoCommand, CreateLoteProdutoResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorService _fornecedorService;

        public CreateLoteProdutoCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            IProdutoService produtoService,
            IFornecedorService fornecedorService)
        {
            _uow = uow;
            _mapper = mapper;
            _produtoService = produtoService;
            _fornecedorService = fornecedorService;
        }

        public async Task<CreateLoteProdutoResponse> Handle(CreateLoteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoService.GetAndValidateEntityAsync(request.ProdutoId);
            var fornecedor = await _fornecedorService.GetAndValidateEntityAsync(request.FornecedorId);

            var lote = _mapper.Map<LoteProduto>(request);
            var movimentacao = _mapper.Map<MovimentacaoProduto>(request);

            lote.Produto = produto;
            lote.Fornecedor = fornecedor;
            lote.EmpresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            movimentacao.LoteProduto = lote;
            movimentacao.Produto = produto;
            movimentacao.UsuarioId = 1;
            movimentacao.EmpresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            await _uow.LotesProdutos.AddAsync(lote, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.MovimentacoesProdutos.AddAsync(movimentacao, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateLoteProdutoResponse>(lote);

            return await Task.FromResult(response);
        }
    }
}
