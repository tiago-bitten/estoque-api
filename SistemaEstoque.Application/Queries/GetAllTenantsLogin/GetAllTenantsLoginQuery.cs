using MediatR;

namespace SistemaEstoque.Application.Queries.GetAllTenantsLogin;

public class GetAllTenantsLoginQuery : IRequest<GetAllTenantsLoginResponse>
{
    public string Email { get; set; }
}