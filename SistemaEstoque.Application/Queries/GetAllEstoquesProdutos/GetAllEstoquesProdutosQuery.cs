using MediatR;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

namespace SistemaEstoque.Application.Queries.GetAllEstoquesProdutos
{
    public class GetAllEstoquesProdutosQuery : IRequest<GetAllEstoquesProdutosResponse>, PagedQuery
    {
        public GetAllEstoquesProdutosQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
