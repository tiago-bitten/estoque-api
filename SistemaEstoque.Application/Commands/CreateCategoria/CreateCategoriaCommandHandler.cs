using AutoMapper;
using MediatR;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Commands.CreateCategoria
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, CreateCategoriaResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateCategoriaCommandHandler(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CreateCategoriaResponse> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = _mapper.Map<Categoria>(request);
            
            var existsCategoria = await _uow.Categorias.GetByNomeAsync(request.Nome, EMPRESA_CONSTANTE.ID_EMPRESA);
            if (existsCategoria != null)
                throw new Exception("Categoria já cadastrada");


            await _uow.Categorias.AddAsync(categoria, EMPRESA_CONSTANTE.ID_EMPRESA);
            await _uow.CommitAsync();

            var response = _mapper.Map<CreateCategoriaResponse>(categoria);

            return await Task.FromResult(response);
        }
    }
}
