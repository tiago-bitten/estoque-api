using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllTotalizadores
{
    public class GetAllLotesTotalizadoresResponse : List<LoteTotalizadorDTO>, IPagedResponse
    {
        public GetAllLotesTotalizadoresResponse(List<LoteTotalizadorDTO> loteTotalizadoresDTO, int total)
        {
            this.AddRange(loteTotalizadoresDTO);
            Total = total;
        }

        public int Total { get; set; }
    }
}
