using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateEstoque
{
    public class CreateEstoqueCommandHandler : IRequestHandler<CreateEstoqueCommand, CreateEstoqueResponse>
    {
        private readonly IUnitOfWork _ouw;
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public CreateEstoqueCommandHandler(
            IUnitOfWork ouw, 
            IMapper mapper,
            IProdutoService produtoService)
        {
            _ouw = ouw;
            _mapper = mapper;
            _produtoService = produtoService;

        }

        public async Task<CreateEstoqueResponse> Handle(CreateEstoqueCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoService.GetAndValidateEntityAsync(request.ProdutoId);

            if (request.QuantidadeMinima <= 0 || request.QuantidadeMaxima <= 0)
                throw new Exception("Quantidade minima e maxima devem ser maiores que 0");

            if (request.QuantidadeMinima > request.QuantidadeMaxima)
                throw new Exception("Quantidade minima deve ser menor que a quantidade maxima");

            var existsEstoque = await _ouw.Estoques.FindAsync(e => e.ProdutoId == request.ProdutoId);
            if (existsEstoque != null)
                throw new Exception($"Estoque para {existsEstoque.Produto.Nome} já foi cadastrado");

            var estoque = _mapper.Map<Estoque>(request);

            estoque.Produto = produto;
            estoque.EmpresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            await _ouw.Estoques.AddAsync(estoque, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _ouw.CommitAsync();
        
            var response = _mapper.Map<CreateEstoqueResponse>(estoque);

            return await Task.FromResult(response);
        }
    }
}
