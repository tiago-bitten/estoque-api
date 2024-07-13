using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllEstoquesInsumos
{
    public class GetAllEstoquesInsumosResponse : List<EstoqueInsumoDTO>, IPagedResponse
    {
        public GetAllEstoquesInsumosResponse(List<EstoqueInsumoDTO> estoquesInsumosDTO, int total)
        {
            this.AddRange(estoquesInsumosDTO);
            Total = total;
        }

        public int Total { get; set; }
    }
}
