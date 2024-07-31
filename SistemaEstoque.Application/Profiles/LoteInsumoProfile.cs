using AutoMapper;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class LoteInsumoProfile : Profile
    {
        public LoteInsumoProfile()
        {
            CreateMap<LoteInsumo, LoteInsumoDTO>();

            CreateMap<LoteItemDTO, LoteInsumo>()
                .ForMember(dest => dest.InsumoId, opt => opt.Ignore());
        }
    }
}
