using AutoMapper;
using SistemaEstoque.Application.Commands.CreateLoteInsumo;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class LoteInsumoProfile : Profile
    {
        public LoteInsumoProfile()
        {
            CreateMap<CreateLoteInsumoCommand, LoteInsumo>();

            CreateMap<LoteInsumo, CreateLoteInsumoResponse>();

            CreateMap<LoteInsumo, LoteInsumoDTO>();

            CreateMap<LoteItemDTO, LoteInsumo>()
                .ForMember(dest => dest.InsumoId, opt => opt.Ignore());
        }
    }
}
