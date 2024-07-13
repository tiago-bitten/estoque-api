using MediatR;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllEstoquesProdutos
{
    public class GetAllEstoquesProdutosQuery : IRequest<GetAllEstoquesProdutosResponse>, IPagedQuery
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
