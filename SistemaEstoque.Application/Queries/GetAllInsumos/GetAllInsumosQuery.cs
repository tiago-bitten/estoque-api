using MediatR;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllInsumos
{
    public class GetAllInsumosQuery : IRequest<GetAllInsumosResponse>, IPagedQuery
    {
        public GetAllInsumosQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get ; set ; }
        public int Take { get ; set ; }
    }
}
