using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Commands.CreateCategoria
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, CreateCategoriaResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateCategoriaCommandHandler(
            IUnitOfWork uow,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<CreateCategoriaResponse> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _currentUserService.GetUsuario();
            var empresa = await _currentUserService.GetEmpresa();

            if (!usuario.PerfilAcesso.PermissaoCategoria.Criar)
                throw new UnauthorizedAccessException("Usuário não tem permissão para criar categorias");

            var categoria = _mapper.Map<Categoria>(request);
            
            var existsCategoria = await _uow.Categorias.FindAsync(x => x.Nome == request.Nome && x.EmpresaId == EMPRESA_CONSTANTE.ID_EMPRESA);
            if (existsCategoria != null)
                throw new Exception("Categoria já cadastrada");

            categoria.Empresa = empresa;

            await _uow.Categorias.AddAsync(categoria, empresa.Id);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateCategoriaResponse>(categoria);

            return await Task.FromResult(response);
        }
    }
}
