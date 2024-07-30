using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.Application.Queries.GetAllTenantsLogin;

public class GetAllTenantsLoginResponse : List<SimpTenantDTO>, IPagedResponse
{
    public GetAllTenantsLoginResponse(List<SimpTenantDTO> simpTenantDtos, int total)
    {
        AddRange(simpTenantDtos);
        Total = total;
    }
    
    public int Total { get; set; }
}