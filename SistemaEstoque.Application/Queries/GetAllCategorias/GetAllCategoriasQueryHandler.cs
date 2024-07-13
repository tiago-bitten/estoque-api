using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
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

            var totalCategorias = await _uow.Categorias.GetAll(empresaId).CountAsync(cancellationToken);
            var categorias = await _uow.Categorias.GetAll(empresaId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync(cancellationToken);

            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);

            return new GetAllCategoriasResponse(categoriasDTO, totalCategorias);
        }
    }
}
