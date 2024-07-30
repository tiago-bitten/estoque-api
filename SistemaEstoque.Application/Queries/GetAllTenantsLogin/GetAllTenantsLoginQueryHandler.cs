using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Interfaces.Repositories;

namespace SistemaEstoque.Application.Queries.GetAllTenantsLogin;

public class GetAllTenantsLoginQueryHandler : IRequestHandler<GetAllTenantsLoginQuery, GetAllTenantsLoginResponse>
{
    private readonly IUnitOfWork _uow;
    private IMapper _mapper;

    public GetAllTenantsLoginQueryHandler(
        IUnitOfWork uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<GetAllTenantsLoginResponse> Handle(GetAllTenantsLoginQuery request, CancellationToken cancellationToken)
    {
        var tenants = await _uow.Empresas
            .FindAll(x => x.Usuarios
                .Any(x => x.Email == request.Email))
            .ToListAsync(cancellationToken);
        
        var tenantDtos = _mapper.Map<List<SimpTenantDTO>>(tenants);

        return new GetAllTenantsLoginResponse(tenantDtos, tenants.Count);
    }
}