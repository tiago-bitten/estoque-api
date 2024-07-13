using AutoMapper;
using SistemaEstoque.Application.Commands.CreateInsumo;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class InsumoProfile : Profile
    {
        public InsumoProfile()
        {
            CreateMap<CreateInsumoCommand, Insumo>();

            CreateMap<Insumo, CreateInsumoResponse>();

            CreateMap<Insumo, InsumoDTO>();
        }
    }
}
