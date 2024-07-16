using MediatR;
using SistemaEstoque.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.Queries.GetAllFornecedores
{
    public class GetAllFornecedoresQuery : IRequest<GetAllFornecedoresResponse>, IPagedQuery
    {
        public GetAllFornecedoresQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
