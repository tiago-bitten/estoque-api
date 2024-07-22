using MediatR;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllTotalizadores
{
    public class GetAllLotesTotalizadoresQuery : IRequest<GetAllLotesTotalizadoresResponse>, IPagedQuery
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
