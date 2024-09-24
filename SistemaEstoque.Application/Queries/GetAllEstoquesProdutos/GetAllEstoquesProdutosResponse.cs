using SistemaEstoque.Application.DTOs;

namespace SistemaEstoque.Application.Queries.GetAllEstoquesProdutos
{
    public class GetAllEstoquesProdutosResponse : List<EstoqueProdutoDTO>, IPagedResponse
    {
        public GetAllEstoquesProdutosResponse(IEnumerable<EstoqueProdutoDTO> estoquesProdutosDTO, int total)
        {
            this.AddRange(estoquesProdutosDTO);
            Total = total;
        }

        public int Total { get ; set ; }
    }
}
