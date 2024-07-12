using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllCategorias
{
    public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, GetAllCategoriasResponse>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllCategoriasQueryHandler(
            IUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetAllCategoriasResponse> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            // ALTERAR_EMPRESA
            var empresaId = EMPRESA_CONSTANTE.ID_EMPRESA;

            var categorias = await _uow.Categorias.GetAllAsync(empresaId);

            var response = _mapper.Map<GetAllCategoriasResponse>(categorias);

            return await Task.FromResult(response);
        }
    }
}
