using AutoMapper;
using SistemaEstoque.Application.Commands.CreateLote;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class LoteProdutoProfile : Profile
    {
        public LoteProdutoProfile()
        {
            CreateMap<CreateLoteProdutoCommand, LoteProduto>();

            CreateMap<LoteProduto, CreateLoteProdutoResponse>();
        }
    }
}
