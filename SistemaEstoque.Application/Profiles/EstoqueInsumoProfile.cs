using AutoMapper;
using SistemaEstoque.Application.Commands.CreateEstoqueInsumo;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class EstoqueInsumoProfile : Profile
    {
        public EstoqueInsumoProfile()
        {
            CreateMap<CreateEstoqueInsumoCommand, EstoqueInsumo>();

            CreateMap<EstoqueInsumo, CreateEstoqueInsumoResponse>();

            CreateMap<EstoqueInsumo, EstoqueInsumoDTO>();
        }
    }
}
