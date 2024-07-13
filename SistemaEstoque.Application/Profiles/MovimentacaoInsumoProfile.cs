using AutoMapper;
using SistemaEstoque.Application.Commands.CreateEstoqueInsumo;
using SistemaEstoque.Application.Commands.CreateLoteInsumo;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.Profiles
{
    public class MovimentacaoInsumoProfile : Profile
    {
        public MovimentacaoInsumoProfile()
        {
            CreateMap<CreateLoteInsumoCommand, MovimentoInsumo>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => ETipoMovimentacao.Entrada))
                .ForMember(dest => dest.DataMovimentacao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Origem, opt => opt.MapFrom(src => EOrigemMovimentacao.EntradaLote));
        
            CreateMap<CreateEstoqueInsumoCommand, MovimentoInsumo>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => ETipoMovimentacao.Entrada))
                .ForMember(dest => dest.DataMovimentacao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Origem, opt => opt.MapFrom(src => EOrigemMovimentacao.CriacaoEstoque));
        }
    }
}
