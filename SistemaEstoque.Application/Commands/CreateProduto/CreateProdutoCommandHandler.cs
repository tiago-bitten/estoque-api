using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateProduto
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, CreateProdutoResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;

        public CreateProdutoCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            ICategoriaService categoriaService)
        {
            _uow = uow;
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        public async Task<CreateProdutoResponse> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaService.GetAndValidateEntityAsync(request.CategoriaId);

            var produto = _mapper.Map<Produto>(request);

            produto.Categoria = categoria;
            produto.EmpresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            await _uow.Produtos.AddAsync(produto, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateProdutoResponse>(produto);

            return await Task.FromResult(response);
        }
    }
}
