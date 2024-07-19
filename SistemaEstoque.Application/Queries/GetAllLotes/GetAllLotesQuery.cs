using MediatR;
using SistemaEstoque.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.Queries.GetAllLotes
{
    public class GetAllLotesQuery : IRequest<GetAllLotesResponse>, IPagedQuery
    {
        public GetAllLotesQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
