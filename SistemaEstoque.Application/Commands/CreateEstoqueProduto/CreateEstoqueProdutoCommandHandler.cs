using AutoMapper;
using MediatR;
using SistemaEstoque.Application.Commands.CreateEstoque;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateEstoqueProduto
{
    public class CreateEstoqueProdutoCommandHandler : IRequestHandler<CreateEstoqueProdutoCommand, CreateEstoqueProdutoResponse>
    {
        private readonly IUnitOfWork _ouw;
        private readonly IMapper _mapper;
        private readonly IItemService _itemService;
        private readonly ICurrentUserService _currentUserService;

        public CreateEstoqueProdutoCommandHandler(
            IUnitOfWork ouw, 
            IMapper mapper,
            IItemService itemService, ICurrentUserService currentUserService)
        {
            _ouw = ouw;
            _mapper = mapper;
            _itemService = itemService;
            _currentUserService = currentUserService;
        }

        public async Task<CreateEstoqueProdutoResponse> Handle(CreateEstoqueProdutoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();
            
            var produto = await _itemService.GetAndValidateEntityAsync(request.ProdutoId);

            if (request.QuantidadeMinima <= 0 || request.QuantidadeMaxima <= 0)
                throw new Exception("Quantidade minima e maxima devem ser maiores que 0");

            if (request.QuantidadeMinima > request.QuantidadeMaxima)
                throw new Exception("Quantidade minima deve ser menor que a quantidade maxima");

            var existsEstoque = await _ouw.Estoques.FindAsync(e => e.ProdutoId == request.ProdutoId && e.Removido == false);
            if (existsEstoque != null)
                throw new Exception($"Estoque para {existsEstoque.Produto.Nome} já foi cadastrado");

            var estoque = _mapper.Map<EstoqueProduto>(request);

            estoque.Produto = produto;
            estoque.Empresa = empresa;

            await _ouw.Estoques.AddAsync(estoque, empresa.Id);
            await _ouw.CommitAsync();
        
            var response = _mapper.Map<CreateEstoqueProdutoResponse>(estoque);

            return await Task.FromResult(response);
        }
    }
}
