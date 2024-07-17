using AutoMapper;
using SistemaEstoque.Application.Commands.CreateLote;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class LoteProdutoProfile : Profile
    {
        public LoteProdutoProfile()
        {
            CreateMap<CreateLoteProdutoCommand, LoteProduto>();

            CreateMap<LoteProduto, CreateLoteProdutoResponse>();

            CreateMap<LoteProduto, LoteProdutoDTO>();

            CreateMap<LoteItemDTO, LoteProduto>()
                .ForMember(dest => dest.ProdutoId, opt => opt.Ignore());
        }
    }
}
