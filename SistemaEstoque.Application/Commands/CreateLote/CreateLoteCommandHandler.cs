using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateLote
{
    public class CreateLoteCommandHandler : IRequestHandler<CreateLoteCommand, CreateLoteResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorService _fornecedorService;

        public CreateLoteCommandHandler(
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

        public async Task<CreateLoteResponse> Handle(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoService.GetAndValidateEntityAsync(request.ProdutoId);
            var fornecedor = await _fornecedorService.GetAndValidateEntityAsync(request.FornecedorId);

            var lote = _mapper.Map<Lote>(request);
            var movimentacao = _mapper.Map<Movimentacao>(request);

            lote.Produto = produto;
            lote.Fornecedor = fornecedor;

            movimentacao.Lote = lote;
            movimentacao.Produto = produto;
            movimentacao.UsuarioId = 1;

            await _uow.Lotes.AddAsync(lote, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.Movimentacoes.AddAsync(movimentacao, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateLoteResponse>(lote);

            return await Task.FromResult(response);
        }
    }
}
