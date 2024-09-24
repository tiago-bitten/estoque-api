using MediatR;

namespace SistemaEstoque.Application.Queries.GetAllInsumos
{
    public class GetAllInsumosQuery : IRequest<GetAllInsumosResponse>, PagedQuery
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
