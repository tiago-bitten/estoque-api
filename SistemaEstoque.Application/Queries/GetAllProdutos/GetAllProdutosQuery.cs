using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.Queries.GetAllProdutos
{
    public class GetAllProdutosQuery : IRequest<GetAllProdutosResponse>, PagedQuery
    {
        public GetAllProdutosQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get ; set; }
        public int Take { get; set ; }
    }
}
