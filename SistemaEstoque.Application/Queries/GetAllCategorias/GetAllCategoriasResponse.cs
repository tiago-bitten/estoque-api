using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllCategorias
{
    public class GetAllCategoriasResponse : List<CategoriaDTO>, IPagedResponse
    {
        public int Total { get ; set ; }
     
        public GetAllCategoriasResponse(IEnumerable<CategoriaDTO> items, int total) 
        {
            AddRange(items);
            Total = total;
        }
    }
}
