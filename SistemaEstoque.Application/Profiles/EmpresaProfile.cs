using AutoMapper;
using SistemaEstoque.Application.Commands.CreateEmpresa;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CreateEmpresaCommand, Empresa>();
            CreateMap<Empresa, CreateEmpresaResponse>();
        }
    }
}
