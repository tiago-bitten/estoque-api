using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;

namespace SistemaEstoque.Application.Queries.GetAllCategorias
{
    public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, GetAllCategoriasResponse>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public GetAllCategoriasQueryHandler(
            IUnitOfWork uow,
            IMapper mapper,
            ITokenService tokenService)
        {
            _uow = uow;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<GetAllCategoriasResponse> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
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
