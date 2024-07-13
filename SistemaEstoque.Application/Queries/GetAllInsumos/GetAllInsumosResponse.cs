using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllInsumos
{
    public class GetAllInsumosResponse : List<InsumoDTO>, IPagedResponse<InsumoDTO>
    {
        public GetAllInsumosResponse(IEnumerable<InsumoDTO> insumosDTO, int total) 
        {
            this.AddRange(insumosDTO);
            Total = total;
        }

        public int Total { get ; set ; }
    }
}