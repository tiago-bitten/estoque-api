using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Shared.Util;

namespace SistemaEstoque.Application.Queries.GetAllCategorias
{
    public class GetAllCategoriasResponse : PagedResponse<CategoriaDto>
    {

        public GetAllCategoriasResponse(PagedResult<CategoriaDto> categorias) : base(categorias)
        {
        }
    }
}