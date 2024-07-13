using MediatR;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllEstoquesInsumos
{
    public class GetAllEstoquesInsumosQuery : IRequest<GetAllEstoquesInsumosResponse>, IPagedQuery
    {
        public GetAllEstoquesInsumosQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
