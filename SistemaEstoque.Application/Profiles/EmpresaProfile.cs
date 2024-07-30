using AutoMapper;
using SistemaEstoque.Application.Commands.CreateEmpresa;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CreateEmpresaCommand, Empresa>();
            CreateMap<Empresa, CreateEmpresaResponse>();

            CreateMap<Empresa, SimpTenantDTO>()
                .ForMember(dest => dest.Fantasia, opt => opt.MapFrom(x => x.Nome));
        }
    }
}
