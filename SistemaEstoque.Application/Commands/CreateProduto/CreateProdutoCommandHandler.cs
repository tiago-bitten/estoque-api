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
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;
            var usuarioId = 1;

            var usuario = await _uow.Usuarios.GetByIdAsync(usuarioId);

            if (!usuario.PerfilAcesso.PermissaoProduto.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar produtos");

            var categoria = await _categoriaService.GetAndValidateEntityAsync(request.CategoriaId);

            var produto = _mapper.Map<Produto>(request);

            produto.Categoria = categoria;

            await _uow.Produtos.AddAsync(produto, empresaId);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateProdutoResponse>(produto);

            return await Task.FromResult(response);
        }
    }
}
