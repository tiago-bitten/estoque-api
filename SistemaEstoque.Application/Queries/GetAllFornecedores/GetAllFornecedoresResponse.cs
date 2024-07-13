using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllFornecedores
{
    public class GetAllFornecedoresResponse : List<FornecedorDTO>, IPagedResponse
    {
        public GetAllFornecedoresResponse(List<FornecedorDTO> fornecedoresDTO, int total)
        {
            this.AddRange(fornecedoresDTO);
            Total = total;
        }

        public int Total { get; set; }
    }
}
