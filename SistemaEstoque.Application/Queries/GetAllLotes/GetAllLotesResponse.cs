using SistemaEstoque.Application.DTOs;

namespace SistemaEstoque.Application.Queries.GetAllLotes
{
    public class GetAllLotesResponse : List<LoteDTO>, IPagedResponse
    {
        public GetAllLotesResponse(IEnumerable<LoteDTO> lotesDTO, int total)
        {
            this.AddRange(lotesDTO);
            Total = total;
        }

        public int Total { get; set; }
    }
}
