using MediatR;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllCategorias
{
    public class GetAllCategoriasQuery : IRequest<GetAllCategoriasResponse>, IPagedQuery
    {
        public GetAllCategoriasQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get ; set; }
        public int Take { get; set ; }
    }
}
    