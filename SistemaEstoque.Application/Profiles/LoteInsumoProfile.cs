using AutoMapper;
using SistemaEstoque.Application.Commands.CreateLoteInsumo;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class LoteInsumoProfile : Profile
    {
        public LoteInsumoProfile()
        {
            CreateMap<CreateLoteInsumoCommand, LoteInsumo>();

            CreateMap<LoteInsumo, CreateLoteInsumoResponse>();
        }
    }
}
