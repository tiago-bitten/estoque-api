using AutoMapper;
using MediatR;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Shared.Extensions;

namespace SistemaEstoque.Application.Queries.GetAllCategorias;

public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, GetAllCategoriasResponse>
{
    private readonly IUnitOfWork _uow;
    private readonly IAmbienteUsuario _ambienteUsuario;
    
    public GetAllCategoriasQueryHandler(IUnitOfWork uow, IAmbienteUsuario ambienteUsuario)
    {
        _uow = uow;
        _ambienteUsuario = ambienteUsuario;
    }

    public async Task<GetAllCategoriasResponse> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
    {
        var ambiente = await _ambienteUsuario.GetUsuarioAndTenantAsync("PerfilAcesso.PermissaoCategoria");

        if (!ambiente.Usuario.PerfilAcesso.PermissaoCategoria.Visualizar)
            throw new UnauthorizedAccessException();
        
        var categorias = await _uow.Categorias.GetAll()
            .Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            })
            .ToPagedResultAsync(request.Page, request.Size);

        var response = new GetAllCategoriasResponse(categorias);

        return response;
    }
}