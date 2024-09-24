using MediatR;

namespace SistemaEstoque.Application.Queries.GetAllTotalizadores
{
    public class GetAllLotesTotalizadoresQuery : IRequest<GetAllLotesTotalizadoresResponse>, PagedQuery
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public GetAllLotesTotalizadoresQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
