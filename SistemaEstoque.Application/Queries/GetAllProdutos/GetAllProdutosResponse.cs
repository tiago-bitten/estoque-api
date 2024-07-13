using Microsoft.EntityFrameworkCore.Query.Internal;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllProdutos
{
    public class GetAllProdutosResponse : List<ProdutoDTO>, IPagedResponse<ProdutoDTO>
    {
        public GetAllProdutosResponse(IEnumerable<ProdutoDTO> produtosDTO, int total)
        {
            this.AddRange(produtosDTO);
            Total = total;
        }

        public int Total { get ; set ; }
    }
}
