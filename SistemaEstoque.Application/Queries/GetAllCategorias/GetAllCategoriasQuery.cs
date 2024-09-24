using MediatR;

namespace SistemaEstoque.Application.Queries.GetAllCategorias;

public class GetAllCategoriasQuery : PagedQuery, IRequest<GetAllCategoriasResponse>
{
    public GetAllCategoriasQuery(int page, int size) : base(page, size)
    {
    }
}