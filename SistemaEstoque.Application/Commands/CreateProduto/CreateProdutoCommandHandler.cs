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
        private readonly ICurrentUserService _currentUserService;

        public CreateProdutoCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            ICategoriaService categoriaService, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _categoriaService = categoriaService;
            _currentUserService = currentUserService;
        }

        public async Task<CreateProdutoResponse> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();

            if (!usuario.PerfilAcesso.PermissaoProduto.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar produtos");

            var categoria = await _categoriaService.GetAndValidateEntityAsync(request.CategoriaId);

            var produto = _mapper.Map<Produto>(request);

            produto.Categoria = categoria;

            await _uow.Produtos.AddAsync(produto, empresa.Id);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateProdutoResponse>(produto);

            return await Task.FromResult(response);
        }
    }
}
