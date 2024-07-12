using AutoMapper;
using SistemaEstoque.Application.Commands.CreateLote;
using SistemaEstoque.Application.Commands.CreateLoteInsumo;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using SistemaEstoque.Infra.Migrations;

namespace SistemaEstoque.Application.Profiles
{
    public class MovimentacaoProdutoProfile : Profile
    {
        public MovimentacaoProdutoProfile()
        {
            CreateMap<CreateLoteProdutoCommand, MovimentacaoProduto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => ETipoMovimentacao.Entrada))
                .ForMember(dest => dest.DataMovimentacao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Origem, opt => opt.MapFrom(src => EOrigemMovimentacao.EntradaLote));
       
        }
    }
}
